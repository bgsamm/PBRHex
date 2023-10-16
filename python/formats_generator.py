"""
Generates a C# source file for parsing files in a given format.

Given an XML file conforming to the schema in 'fmt.xsd', generates
a corresponding C# source file for parsing binary files in the format
defined by the XML into C# objects.
"""
import os
import xmlschema
import xml.etree.ElementTree as xml
from argparse import ArgumentParser, Namespace
from pathlib import Path

SCHEMA = xmlschema.XMLSchema(os.path.join("formats", "fmt.xsd"))


class FormatsCodeGenerator:
    def __init__(self):
        pass


def parse_args() -> Namespace:
    parser = ArgumentParser()

    parser.add_argument("infile", type=Path)
    parser.add_argument("outfile", type=Path)
    parser.add_argument("namespace")
    parser.add_argument("classname")
    parser.add_argument("--tab-size", type=int, default=4)

    return parser.parse_args()


if __name__ == "__main__":
    args = parse_args()

    generator = FormatsCodeGenerator()
