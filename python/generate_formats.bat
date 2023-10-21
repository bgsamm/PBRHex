@echo off
for %%i in (formats/*.xml) do (
  python "formats_generator.py" "formats\%%i" %1
)