# pylint: disable=missing-class-docstring,missing-function-docstring
"""Generates a C# partial class in accordance
with the commands contained in a json file
"""
import json
from pathlib import Path
from argparse import (
    ArgumentParser,
    Namespace
)
from typing import Any

JsonObj = dict[str, Any]


def kebab_to_camel_case(name: str) -> str:
    tokens = name.split('-')
    return tokens[0] + ''.join(token.capitalize() for token in tokens[1:])


def kebab_to_pascal_case(name: str) -> str:
    return ''.join(token.capitalize() for token in name.split('-'))


class CommandCodeGenerator:

    commands: list[JsonObj]

    def __init__(self,
                 namespace: str,
                 classname: str,
                 tab_size: int = 4):
        self.namespace = namespace
        self.classname = classname
        self.tab_size = tab_size

        self.commands = []

    @property
    def tab(self):
        return ' ' * self.tab_size

    def load_commands(self,
                      path: Path,
                      encoding: str = 'utf-8'):
        self.commands = []

        with open(path, encoding=encoding) as file:
            commands = json.load(file)

        assert isinstance(commands, list)
        assert all(isinstance(e, dict) for e in commands)

        for command in commands:
            if 'arguments' not in command:
                command['arguments'] = []
            if 'options' not in command:
                command['options'] = []

        self.commands = commands

    def _format_lines(self, lines: list[str], indent: int) -> str:
        tab = self.tab * indent

        output = ""
        for i, line in enumerate(lines):
            line = line.strip()
            if i > 0 and len(line) > 0:
                line = tab + line
            output += line + '\n'

        return output[:-1]

    def get_source_code(self) -> str:
        source = f"""// Auto-generated by commands.py
using System.CommandLine;

namespace {self.namespace}
{{
    internal partial class {self.classname}
    {{
        private readonly Dictionary<string, Command> Commands = new();

        {self._gen_option_value_enums(indent=2)}

        private void InitCommands() {{
            {self._gen_add_commands(indent=3)}
        }}

        {self._gen_add_command_methods(indent=2)}

        {self._gen_partial_methods(indent=2)}
    }}
}}
"""
        return source

    def _gen_option_value_enums(self, indent: int = 0) -> str:
        lines: list[str] = []

        for command in self.commands:
            for option in command['options']:
                if 'values' not in option:
                    continue
                enum = self._gen_option_value_enum(command, option, indent)
                lines.append(enum)

        return self._format_lines(lines, indent)

    def _gen_option_value_enum(self,
                               command: JsonObj,
                               option: JsonObj,
                               indent: int = 0) -> str:
        tab = self.tab * indent

        enum_name = self._get_option_enum_name(command['name'], option['name'])

        values = [f"{self.tab}{value}," for value in option['values']]

        lines = f"""
{tab}private enum {enum_name} {{
{tab}{self.tab}{self._format_lines(values, indent + 1)}
{tab}}}
"""
        return lines

    def _gen_add_commands(self, indent: int = 0) -> str:
        lines: list[str] = []

        for command in self.commands:
            name_str = f"\"{command['name']}\""
            method_name = self._get_create_command_method_name(command['name'])
            lines.append(f"Commands.Add({name_str}, {method_name}());")

        return self._format_lines(lines, indent)

    def _gen_add_command_methods(self, indent: int = 0) -> str:
        lines: list[str] = []

        for command in self.commands:
            method_source = self._gen_add_command_method(command, indent)
            lines.append(method_source)
            lines.append('')

        return self._format_lines(lines[:-1], indent)

    def _gen_add_command_method(self,
                                command: JsonObj,
                                indent: int = 0) -> str:
        tab = self.tab * indent

        method_name = self._get_create_command_method_name(command['name'])
        body = self._gen_add_command_method_body(command)

        lines = f"""
{tab}private Command {method_name}() {{
{tab}{self.tab}{self._format_lines(body, indent + 1)}
{tab}}}
"""
        return lines

    def _gen_add_command_method_body(self, command: JsonObj) -> list[str]:
        body: list[str] = []

        name_str = f"\"{command['name']}\""
        desc_str = f"\"{command['description']}\""
        body.append(f"Command command = new({name_str}, {desc_str});")
        if 'alias' in command:
            body.append(f"command.AddAlias(\"{command['alias']}\");")
        body.append('')

        arg_names, arg_statements = self._gen_command_arguments(command)
        if len(arg_statements) > 0:
            body += arg_statements
            body.append('')

        opt_names, opt_statements = self._gen_command_options(command)
        if len(opt_statements) > 0:
            body += opt_statements
            body.append('')

        param_names = arg_names + opt_names

        method_name = self._get_handle_method_name(command['name'])
        for param in param_names:
            body.append(f"command.Add({param});")
        params = ''.join(', ' + param for param in param_names)
        body.append(f"command.SetHandler({method_name}{params});")

        body.append('')
        body.append('return command;')

        return body

    def _gen_command_arguments(self, command: JsonObj) -> tuple[list[str], list[str]]:
        assert 'arguments' in command

        arg_statements: list[str] = []

        arg_names: list[str] = []
        for argument in command['arguments']:
            name = self._get_argument_name(argument['name'])
            arg_names.append(name)

            name_str = f"\"{argument['name']}\""
            desc_str = f"\"{argument['description']}\""
            type_ = self._get_parameter_type(command, argument)
            arg_statements.append(
                f"Argument<{type_}> {name} = new({name_str}, {desc_str});")

            if 'default' in argument:
                arg_statements.append(
                    f"{name}.SetDefaultValue(\"{argument['default']}\");")

        return arg_names, arg_statements

    def _gen_command_options(self, command: JsonObj) -> tuple[list[str], list[str]]:
        assert 'options' in command

        opt_statements: list[str] = []

        opt_names: list[str] = []
        for option in command['options']:
            name = self._get_option_name(option['name'])
            opt_names.append(name)

            name_str = f"\"--{option['name']}\""
            desc_str = f"\"{option['description']}\""
            type_ = self._get_parameter_type(command, option)
            opt_statements.append(
                f"Option<{type_}> {name} = new({name_str}, {desc_str});")

        return opt_names, opt_statements

    def _gen_partial_methods(self, indent: int = 0) -> str:
        lines: list[str] = []

        for command in self.commands:
            method_name = self._get_handle_method_name(command['name'])
            params = ', '.join(self._gen_method_param_list(command))
            lines.append(f"private partial void {method_name}({params});")

        return self._format_lines(lines, indent)

    def _gen_method_param_list(self, command: JsonObj) -> list[str]:
        param_list: list[str] = []

        params = command['arguments'] + command['options']
        for param in params:
            name = kebab_to_camel_case(param['name'])
            type_ = self._get_parameter_type(command, param)
            param_list.append(f"{type_} {name}")

        return param_list

    def _get_parameter_type(self, command: JsonObj, param: JsonObj) -> str:
        if 'values' in param:
            return self._get_option_enum_name(command['name'],
                                              param['name'])
        if 'type' in param:
            return param['type']
        return 'string'

    def _get_create_command_method_name(self, command: str) -> str:
        name = kebab_to_pascal_case(command)
        return 'Create' + name + 'Command'

    def _get_handle_method_name(self, command: str) -> str:
        name = kebab_to_pascal_case(command)
        return name + 'Handle'

    def _get_argument_name(self, argument: str) -> str:
        name = kebab_to_camel_case(argument)
        return name + 'Argument'

    def _get_option_name(self, option: str) -> str:
        name = kebab_to_camel_case(option)
        return name + 'Option'

    def _get_option_enum_name(self, command: str, option: str) -> str:
        command = kebab_to_pascal_case(command)
        option = kebab_to_pascal_case(option)
        return command + option + 'Value'


def parse_args() -> Namespace:
    parser = ArgumentParser()

    parser.add_argument('infile', type=Path)
    parser.add_argument('outfile', type=Path)
    parser.add_argument('namespace')
    parser.add_argument('classname')
    parser.add_argument('--tab-size', type=int, default=4)

    return parser.parse_args()


def generate_csharp_file():
    args = parse_args()

    generator = CommandCodeGenerator(args.namespace, args.classname)
    generator.load_commands(args.infile)

    source = generator.get_source_code()

    with open(args.outfile, 'w+', encoding='utf-8') as file:
        file.write(source)


if __name__ == '__main__':
    generate_csharp_file()
