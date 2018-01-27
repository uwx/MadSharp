@ECHO OFF
SETLOCAL
SET "sourcedir=.\images"
FOR /r "%sourcedir%" %%a IN (*.png) DO (
 optipng.exe -force -v -o2 "%%a" > optipng.log
)
pause
GOTO :EOF