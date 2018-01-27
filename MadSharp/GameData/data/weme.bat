@REM @ECHO OFF
SETLOCAL
set PREV_DIR=%CD%
cd C:\Portable Programs\waifu2x-converter_x64_1130
SET "sourcedir=C:\Users\Rafael\Documents\GitHub\oshift\OpenNFMM\data\images"
FOR /r "%sourcedir%" %%a IN (*.png) DO (
 waifu2x-converter_x64.exe -i "%%a" -o "%%a"
)
pause
GOTO :EOF
cd %CD%