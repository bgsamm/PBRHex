"""Provides classes that represent various C# language features."""
from __future__ import annotations
from abc import ABC, abstractmethod
import formatting


class CSharpSourceFile:
    usings: list[str]
    content: str

    def __init__(self, tab_size: int | None = None):
        self.usings = []
        self.content = ""
        self.tab_size = tab_size

    def add_using(self, namespace: str):
        self.usings.append(namespace)

    def add_namespace(self, namespace: CSharpNamespace):
        self.content = namespace.to_string()

    def get_source_code(self) -> str:
        source = self.content

        if len(self.usings) > 0:
            usings = "\n".join([f"using {using};" for using in self.usings])
            source = usings + "\n\n" + source

        if self.tab_size is not None:
            source = formatting.tabs_to_spaces(source, self.tab_size)
        return source

    def write(self, path: str):
        source = self.get_source_code()
        with open(path, "w+") as file:
            file.write(source)


class CSharpCodeBlock(ABC):
    @abstractmethod
    def to_string(self) -> str:
        pass


class BlockContainer:
    blocks: list[CSharpCodeBlock]

    def __init__(self):
        self.blocks = []

    def add_block(self, block: CSharpCodeBlock):
        self.blocks.append(block)

    def _blocks_to_string(self) -> str:
        block_strs: list[str] = []
        for block in self.blocks:
            block_strs.append(block.to_string())

        return "\n\n".join(block_strs)


class CSharpNamespace(CSharpCodeBlock, BlockContainer):
    def __init__(self, name: str):
        super().__init__()
        self.name = name

    def to_string(self) -> str:
        body = self._blocks_to_string()

        source = f"""namespace {self.name}
{{
{formatting.indent(body)}
}}"""
        return source


class CSharpClass(CSharpCodeBlock, BlockContainer):
    fields: list[CSharpField]

    def __init__(
        self,
        name: str,
        access: str = "internal",
        static: bool = False,
        abstract: bool = False,
        partial: bool = False,
    ):
        super().__init__()
        self.name = name
        self.access = access
        self.is_static = static
        self.is_abstract = abstract
        self.is_partial = partial

        self.fields = []

    def add_field(self, field: CSharpField):
        self.fields.append(field)

    def add_constructor(
        self,
        access: str = "internal",
        params: list[tuple[str, str]] = [],
        static: bool = False,
    ) -> CSharpMethod:
        constructor = CSharpMethod(
            self.name, None, access=access, params=params, static=static
        )
        self.add_block(constructor)
        return constructor

    def to_string(self) -> str:
        body = self._blocks_to_string()

        fields = "\n".join([field.to_string() for field in self.fields])
        if len(fields) > 0:
            body = fields + "\n\n" + body

        access = self.access + " "
        static = "static " if self.is_static else ""
        abstract = "abstract " if self.is_abstract else ""
        partial = "partial " if self.is_partial else ""
        source = f"""{access}{static}{abstract}{partial}class {self.name}
{{
{formatting.indent(body)}
}}"""
        return source


class CSharpMethod(CSharpCodeBlock):
    def __init__(
        self,
        name: str,
        returnType: str | None,  # 'None' to be used for constructors
        access: str = "private",
        params: list[tuple[str, str]] = [],
        static: bool = False,
        abstract: bool = False,
        partial: bool = False,
    ):
        super().__init__()
        self.name = name
        self.returnType = returnType
        self.params = params
        self.access = access
        self.is_static = static
        self.is_abstract = abstract
        self.is_partial = partial

        self.body = ""

    def add_code(self, code: str, appendNewLine: bool = True):
        if appendNewLine:
            code += "\n"
        self.body += code

    def to_string(self) -> str:
        static = "static " if self.is_static else ""
        abstract = "abstract " if self.is_abstract else ""
        partial = "partial " if self.is_partial else ""
        returnType = f"{self.returnType} " if self.returnType is not None else ""
        paramList = ", ".join([f"{type} {var}" for type, var in self.params])

        source = f"{self.access} {static}{abstract}{partial}{returnType}{self.name}({paramList})"

        if self.is_partial or self.is_abstract:
            source += ";"
        elif len(self.body) == 0:
            source += " { }"
        else:
            source += f""" {{
{formatting.indent(self.body.strip())}
}}"""
        return source


class CSharpEnum(CSharpCodeBlock):
    members: list[str]

    def __init__(self, name: str, access: str = "internal"):
        super().__init__()
        self.name = name
        self.access = access
        self.members = []

    def add_member(self, member: str):
        self.members.append(member)

    def to_string(self) -> str:
        members = "\n".join([f"\t{member}," for member in self.members])
        source = f"""{self.access} enum {self.name}
{{
{members}
}}"""
        return source


class CSharpField:
    def __init__(
        self,
        name: str,
        type: str,
        access: str = "private",
        static: bool = False,
        readonly: bool = False,
        required: bool = False,
        initialValue: str | None = None,
    ):
        self.name = name
        self.type = type
        self.access = access
        self.is_static = static
        self.is_readonly = readonly
        self.is_required = required
        self.initialValue = initialValue

    def to_string(self) -> str:
        static = "static " if self.is_static else ""
        readonly = "readonly " if self.is_readonly else ""
        required = "required " if self.is_required else ""
        initialization = (
            f" = {self.initialValue}" if self.initialValue is not None else ""
        )
        return f"{self.access} {static}{readonly}{required}{self.type} {self.name}{initialization};"
