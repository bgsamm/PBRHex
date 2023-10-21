"""
Generates a C# source file for parsing files in a given format.

Given an XML file conforming to the schema in 'fmt.xsd', generates
a corresponding C# source file for parsing binary files in the format
defined by the XML into C# objects.
"""
from __future__ import annotations
from abc import ABC, abstractmethod
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
    CSharpField,
)
import formatting

SCHEMA = xmlschema.XMLSchema(os.path.join("formats", "fmt.xsd"))
NAMESPACE = "PBRHex.Core.Formats"


class Field(ABC):
    def __init__(self, xml: xml.Element):
        self.xml = xml
        self.name: str = xml.get("id")  # type: ignore
        self.offset: str = xml.get("offset")  # type: ignore
        self.type = self._get_type()

    def _get_type(self) -> str:
        return self.xml.tag

    def _get_child(self) -> Field:
        first_child = self.xml.find("./*[1]")
        if first_child is None:
            raise Exception("Attempted to get the child of a childless field")
        return Field.from_xml(first_child)

    @property
    @abstractmethod
    def size(self) -> int:
        pass

    @abstractmethod
    def get_parse_code(self, withType: bool = True) -> str:
        pass

    @staticmethod
    def from_xml(xml: xml.Element) -> Field:
        if xml.tag == "string":
            return String(xml)
        if xml.tag == "pointer":
            return Pointer(xml)
        if xml.tag == "array":
            return Array(xml)
        return Number(xml)


class Number(Field):
    size_map = {
        "byte": 1,
        "short": 2,
        "int": 4,
        "long": 8,
        "sbyte": 1,
        "ushort": 2,
        "uint": 4,
        "ulong": 8,
        "float": 4,
        "double": 8,
    }

    name_map = {
        "byte": "Byte",
        "short": "Int16",
        "int": "Int32",
        "long": "Int64",
        "sbyte": "SByte",
        "ushort": "UInt16",
        "uint": "UInt32",
        "ulong": "UInt64",
        "float": "Single",
        "double": "Double",
    }

    @property
    def size(self) -> int:
        return Number.size_map[self.type]

    def get_parse_code(self, withType: bool = True) -> str:
        Type = Number.name_map[self.type]
        type_str = f"{self.type} " if withType else ""
        return f"{type_str}{self.name} = reader.Read{Type}({self.offset});"


class String(Field):
    def __init__(self, xml: xml.Element):
        super().__init__(xml)
        self.length = xml.get("length")

    @property
    def size(self) -> int:
        if self.length is None:
            raise Exception("Cannot get size of a variable-length string field")
        return int(self.length)

    def get_parse_code(self, withType: bool = True) -> str:
        type_str = "string " if withType else ""
        args_str = f"{self.offset}"
        if self.length is not None:
            args_str += f", {self.length}"
        return f"{type_str}{self.name} = reader.ReadString({args_str});"


class Pointer(Field):
    count = 0

    def __init__(self, xml: xml.Element):
        super().__init__(xml)
        self._type = xml.attrib["type"]

    def _get_type(self) -> str:
        return self._get_child().type

    @property
    def size(self) -> int:
        return Number.size_map[self._type]

    def get_parse_code(self, withType: bool = True) -> str:
        Pointer.count += 1

        ptr = f"_ptr{Pointer.count}"
        Type = Number.name_map[self._type]
        code = f"{self._type} {ptr} = reader.Read{Type}({self.offset});\n"

        child = self._get_child()
        child.name = self.name
        child.offset = ptr
        code += child.get_parse_code(withType)

        return code


class Array(Field):
    depth = 0
    count = 0

    def __init__(self, xml: xml.Element):
        super().__init__(xml)
        self.length = xml.attrib["length"]

    def _get_type(self) -> str:
        return self._get_child().type + "[]"

    @property
    def size(self) -> int:
        return int(self.length) * self._get_child().size

    def get_parse_code(self, withType: bool = True) -> str:
        Array.depth += 1
        Array.count += 1

        initializer = self.type.replace("[]", f"[{self.length}]", 1)
        type_str = f"{self.type} " if withType else ""
        code = f"{type_str}{self.name} = new {initializer};\n"

        offset = f"_offset{Array.count}"
        code += f"uint {offset} = {self.offset};\n"

        i = f"_i{Array.depth}"
        code += f"for (int {i} = 0; {i} < {self.length}; {i}++) {{\n"

        child = self._get_child()
        child.name = f"{self.name}[{i}]"
        child.offset = offset
        code += formatting.indent(child.get_parse_code(withType=False) + "\n")

        code += formatting.indent(f"{offset} += {child.size};\n")
        code += "}"

        Array.depth -= 1
        return code


class Typedef:
    def __init__(self, xml: xml.Element):
        self.name = xml.attrib["name"]

        self.fields: list[Field] = []
        for field in xml.find("fields"):  # type: ignore
            self.fields.append(Field.from_xml(field))


class Format(Typedef):
    def __init__(self, xml: xml.Element):
        super().__init__(xml)
        self.extension = xml.attrib["extension"]


class FormatCodeGenerator:
    def __init__(self, fmt_xml: str, tab_size: int | None = 4):
        self.tab_size = tab_size
        self._load_format_definition(fmt_xml)

    def _load_format_definition(self, xml_path: str):
        xmlschema.validate(xml_path, SCHEMA)

        root = xml.parse(xml_path).getroot()
        self.format = Format(root)

    def generate_source_file(self) -> CSharpSourceFile:
        command_parser_class = self._generate_main_class()

        namespace_obj = CSharpNamespace(NAMESPACE)
        namespace_obj.add_block(command_parser_class)

        source_file = CSharpSourceFile(self.tab_size)
        source_file.add_using("PBRHex.Core.IO")
        source_file.add_namespace(namespace_obj)

        return source_file

    def _generate_main_class(self) -> CSharpClass:
        class_name = self.get_class_name()
        class_obj = CSharpClass(class_name, access="public")
        class_obj.add_constructor(access="private")

        for field in self.format.fields:
            field_obj = CSharpField(
                field.name, field.type, access="public", required=True
            )
            class_obj.add_field(field_obj)

        parse_method = self._generate_parse_method()
        class_obj.add_block(parse_method)

        return class_obj

    def _generate_parse_method(self) -> CSharpMethod:
        class_name = self.get_class_name()
        method_obj = CSharpMethod(
            "Parse",
            class_name,
            access="public",
            static=True,
            params=[("IByteStream", "stream")],
        )
        method_obj.add_code("BytesReader reader = new(stream);")
        method_obj.add_code("")

        fields = self.format.fields
        for field in fields:
            method_obj.add_code(field.get_parse_code())
            method_obj.add_code("")

        members = ",\n".join([f"{field.name} = {field.name}" for field in fields])
        object_initializer = f"""{class_name} _file = new()
{{
{formatting.indent(members)}
}};
"""
        method_obj.add_code(object_initializer)
        method_obj.add_code("return _file;", False)

        return method_obj

    def get_class_name(self) -> str:
        return f"{self.format.name}File"


def parse_args() -> Namespace:
    parser = ArgumentParser()

    parser.add_argument("infile", type=Path)
    parser.add_argument("outdir", type=Path)
    parser.add_argument("--tab-size", type=int, default=4)

    return parser.parse_args()


if __name__ == "__main__":
    args = parse_args()

    generator = FormatCodeGenerator(args.infile, tab_size=args.tab_size)
    source = generator.generate_source_file()
    source.write(f"{args.outdir}\\{generator.get_class_name()}.cs")
