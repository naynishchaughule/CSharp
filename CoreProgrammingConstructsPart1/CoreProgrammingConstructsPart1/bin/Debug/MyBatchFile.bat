@echo off
rem Comments
rem A batch file for CoreProgrammingConstructsPart1.exe
rem which captures the app's return value.


CoreProgrammingConstructsPart1
@if "%ERRORLEVEL%" == "0" goto success

:fail
echo This application has failed!
echo return value = %ERRORLEVEL%
echo try again with exit code of 0
goto end

:success
echo This application has succeeded!
echo return value = %ERRORLEVEL%
echo naynish p. chaughule

goto end
:end

echo All Done.