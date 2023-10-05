"""
Generates a C# source file for parsing files in a given format.

Given an XML file conforming to the schema in 'fmt.xsd', generates
a corresponding C# source file for parsing binary files in the format
defined by the XML into C# objects.
"""
from pathlib import Path
from argparse import ArgumentParser, Namespace
import xml.etree.ElementTree as xml
import xmlschema

xsd_path = "fmt.xsd"
xml_path = "sdr.fmt.xml"

schema = xmlschema.XMLSchema(xsd_path)
xmlschema.validate(xml_path, schema)

tree = xml.parse(xml_path)
root = tree.getroot()

types = set()
for child in root.findall("type"):
    types.add(child.get("name"))

print(types)


class ParserCodeGenerator:
    def __init__(self, namespace: str, classname: str, tab_size: int = 4):
        self.namespace = namespace
        self.classname = classname
        self.tab_size = tab_size


def parse_args() -> Namespace:
    parser = ArgumentParser()

    parser.add_argument("infile", type=Path)
    parser.add_argument("outfile", type=Path)
    parser.add_argument("namespace")
    parser.add_argument("classname")
    parser.add_argument("--tab-size", type=int, default=4)

    return parser.parse_args()


def generate_csharp_file():
    args = parse_args()

    generator = ParserCodeGenerator(args.namespace, args.classname)
    generator.load_commands(args.infile)

    source = generator.get_source_code()

    with open(args.outfile, "w+", encoding="utf-8") as file:
        file.write(source)


if __name__ == "__main__":
    generate_csharp_file()
