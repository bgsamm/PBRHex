"""Utility functions for formatting code."""


def tabs_to_spaces(source: str, tab_size: int) -> str:
    tab = " " * tab_size
    return source.replace("\t", tab)


def indent(code_block: str) -> str:
    lines: list[str] = []
    for line in code_block.split("\n"):
        if len(line) > 0:
            lines.append(f"\t{line}")
        else:
            lines.append("")

    return "\n".join(lines)


def kebab_to_camel_case(name: str) -> str:
    tokens = name.split("-")
    return tokens[0] + "".join(token.capitalize() for token in tokens[1:])


def kebab_to_pascal_case(name: str) -> str:
    return "".join(token.capitalize() for token in name.split("-"))
