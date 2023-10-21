"""Generates a C# source file for parsing user-defined commands.

Given an XML file conforming to the schema in 'cmd.xsd', generates
a C# partial class for parsing the commands defined within using the
System.CommandLine namespace.
"""
from __future__ import annotations
from argparse import ArgumentParser, Namespace
import os
from pathlib import Path
import xml.etree.ElementTree as xml
import xmlschema
from csharplib import (
    CSharpSourceFile,
    CSharpNamespace,
    CSharpClass,
    CSharpMethod,
    CSharpEnum,
    CSharpField,
)
import formatting

SCHEMA = xmlschema.XMLSchema(os.path.join("commands", "cmd.xsd"))
NAMESPACE = "PBRHex.CLI"


class Symbol:
    name: str
    description: str

    def __init__(self, xml: xml.Element):
        self.name = xml.find("name").text  # type: ignore
        self.description = xml.find("description").text  # type: ignore

    @property
    def name_str(self):
        return '"' + self.name + '"'

    @property
    def desc_str(self):
        return '"' + self.description + '"'


class Command(Symbol):
    aliases: list[str]
    arguments: list[Argument]
    options: list[Option]

    def __init__(self, xml: xml.Element):
        super().__init__(xml)

        self.aliases = [alias.text for alias in xml.findall("alias")]  # type: ignore

        arguments = xml.find("arguments")
        if arguments is not None:
            self.arguments = [Argument(arg) for arg in arguments]
        else:
            self.arguments = []

        options = xml.find("options")
        if options is not None:
            self.options = [Option(opt) for opt in options]
        else:
            self.options = []


class Parameter(Symbol):
    type: str
    values: list[str] | None
    default: str | None

    def __init__(self, xml: xml.Element):
        super().__init__(xml)

        self.type = xml.attrib["type"]

        values = xml.find("values")
        if values is not None:
            self.values = [value.text for value in values]  # type: ignore
        else:
            self.values = None

        default = xml.find("default")
        self.default = default.text if default is not None else None

    @property
    def default_str(self):
        if self.default is None:
            raise AttributeError(f"Parameter {self.name_str} has no default value")
        return '"' + self.default + '"'


class Argument(Parameter):
    def __init__(self, xml: xml.Element):
        super().__init__(xml)


class Option(Parameter):
    def __init__(self, xml: xml.Element):
        super().__init__(xml)

    @property
    def name_str(self):
        return '"--' + self.name + '"'


class CommandsCodeGenerator:
    def __init__(self, cmd_xml: str, tab_size: int | None = 4):
        self.tab_size = tab_size
        self._load_commands(cmd_xml)

    def _load_commands(self, xml_path: str):
        xmlschema.validate(xml_path, SCHEMA)

        root = xml.parse(xml_path).getroot()
        self.commands = [Command(cmd) for cmd in root.findall("command")]

    def generate_source_file(self) -> CSharpSourceFile:
        command_parser_class = self._generate_main_class()

        namespace_obj = CSharpNamespace(NAMESPACE)
        namespace_obj.add_block(command_parser_class)

        source_file = CSharpSourceFile(self.tab_size)
        source_file.add_using("System.CommandLine")
        source_file.add_namespace(namespace_obj)

        return source_file

    def _generate_main_class(self) -> CSharpClass:
        commands_field = CSharpField(
            "Commands",
            "Dictionary<string, Command>",
            readonly=True,
            initialValue="new()",
        )

        class_obj = CSharpClass("CommandParser", partial=True)
        class_obj.add_field(commands_field)

        for command in self.commands:
            params = command.arguments + command.options
            if any([param.type == "enum" for param in params]):
                enums_class = self._gen_enum_class(command)
                class_obj.add_block(enums_class)

        init_commands_method = self._generate_init_commands_method()
        class_obj.add_block(init_commands_method)

        for command in self.commands:
            create_command_method = self._generate_create_command_method(command)
            class_obj.add_block(create_command_method)

        for command in self.commands:
            command_handle = self._generate_command_handle_method(command)
            class_obj.add_block(command_handle)

        return class_obj

    def _generate_init_commands_method(self) -> CSharpMethod:
        method_obj = CSharpMethod("InitCommands", "void")

        for command in self.commands:
            method_name = self._get_create_command_method_name(command)
            method_obj.add_code(f"Commands.Add({command.name_str}, {method_name}());")

        return method_obj

    def _generate_create_command_method(self, command: Command) -> CSharpMethod:
        name = self._get_create_command_method_name(command)
        method_obj = CSharpMethod(name, "Command")

        method_obj.add_code(
            f"Command command = new({command.name_str}, {command.desc_str});"
        )

        for alias in command.aliases:
            method_obj.add_code(f'command.AddAlias("{alias}");')
        method_obj.add_code("")

        arg_names, arg_statements = self._get_command_arguments(command)
        if len(arg_statements) > 0:
            for statement in arg_statements:
                method_obj.add_code(statement)
            method_obj.add_code("")

        opt_names, opt_statements = self._get_command_options(command)
        if len(opt_statements) > 0:
            for statement in opt_statements:
                method_obj.add_code(statement)
            method_obj.add_code("")

        param_names = arg_names + opt_names
        for param in param_names:
            method_obj.add_code(f"command.Add({param});")
        params = "".join([f", {param}" for param in param_names])

        handle_name = self._get_handle_method_name(command)
        method_obj.add_code(f"command.SetHandler({handle_name}{params});")

        method_obj.add_code("")
        method_obj.add_code("return command;", False)

        return method_obj

    def _generate_command_handle_method(self, command: Command) -> CSharpMethod:
        method_name = self._get_handle_method_name(command)
        params = self._get_handle_param_list(command)
        command_handle = CSharpMethod(method_name, "void", params=params, partial=True)
        return command_handle

    def _get_command_arguments(self, command: Command) -> tuple[list[str], list[str]]:
        arg_statements: list[str] = []

        arg_names: list[str] = []
        for argument in command.arguments:
            arg_name = self._get_argument_name(argument)
            arg_names.append(arg_name)

            type = self._get_parameter_type(command, argument)
            arg_statements.append(
                f"Argument<{type}> {arg_name} = new({argument.name_str}, {argument.desc_str});"
            )

            if argument.default is not None:
                arg_statements.append(
                    f"{arg_name}.SetDefaultValue({argument.default_str});"
                )

        return arg_names, arg_statements

    def _gen_enum_class(self, command: Command) -> CSharpClass:
        class_name = formatting.kebab_to_pascal_case(command.name)
        class_obj = CSharpClass(class_name, access="private", static=True)

        params = command.arguments + command.options
        for param in filter(lambda x: x.type == "enum", params):
            enum_name = formatting.kebab_to_pascal_case(param.name)
            enum_obj = CSharpEnum(enum_name)

            assert param.values is not None
            for value in param.values:
                enum_obj.add_member(value)

            class_obj.add_block(enum_obj)

        return class_obj

    def _get_command_options(self, command: Command) -> tuple[list[str], list[str]]:
        opt_statements: list[str] = []

        opt_names: list[str] = []
        for option in command.options:
            opt_name = self._get_option_name(option)
            opt_names.append(opt_name)

            type = self._get_parameter_type(command, option)
            opt_statements.append(
                f"Option<{type}> {opt_name} = new({option.name_str}, {option.desc_str});"
            )

        return opt_names, opt_statements

    def _get_handle_param_list(self, command: Command) -> list[tuple[str, str]]:
        param_list: list[tuple[str, str]] = []

        params = command.arguments + command.options
        for param in params:
            name = formatting.kebab_to_camel_case(param.name)
            type = self._get_parameter_type(command, param)
            param_list.append((type, name))

        return param_list

    def _get_parameter_type(self, command: Command, param: Parameter) -> str:
        if param.type == "enum":
            return self._get_enum_name(command, param)
        return param.type

    def _get_create_command_method_name(self, command: Command) -> str:
        name = formatting.kebab_to_pascal_case(command.name)
        return "Create" + name + "Command"

    def _get_handle_method_name(self, command: Command) -> str:
        name = formatting.kebab_to_pascal_case(command.name)
        return name + "Handle"

    def _get_argument_name(self, argument: Argument) -> str:
        name = formatting.kebab_to_camel_case(argument.name)
        return name + "Argument"

    def _get_option_name(self, option: Option) -> str:
        name = formatting.kebab_to_camel_case(option.name)
        return name + "Option"

    def _get_enum_name(self, command: Command, param: Parameter) -> str:
        cmd_name = formatting.kebab_to_pascal_case(command.name)
        param_name = formatting.kebab_to_pascal_case(param.name)
        return f"{cmd_name}.{param_name}"


def parse_args() -> Namespace:
    parser = ArgumentParser()

    parser.add_argument("infile", type=Path)
    parser.add_argument("outfile", type=Path)
    parser.add_argument("--tab-size", type=int, default=4)

    return parser.parse_args()


if __name__ == "__main__":
    args = parse_args()

    generator = CommandsCodeGenerator(args.infile, tab_size=args.tab_size)
    source = generator.generate_source_file()
    source.write(args.outfile)
