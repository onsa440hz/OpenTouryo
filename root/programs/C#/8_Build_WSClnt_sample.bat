setlocal

@rem --------------------------------------------------
@rem Turn off the echo function.
@rem --------------------------------------------------
@echo off

@rem --------------------------------------------------
@rem Get the path to the executable file.
@rem --------------------------------------------------
set CURRENT_DIR="%~dp0"

@rem --------------------------------------------------
@rem Execution of the common processing.
@rem --------------------------------------------------
call %CURRENT_DIR%z_Common.bat

rem --------------------------------------------------
rem Batch build of WSClientWin_sample.
rem --------------------------------------------------
%BUILDFILEPATH% %COMMANDLINE% "Samples\WS_sample\WSClient_sample\WSClientWin_sample\WSClientWin_sample.sln"

pause

rem --------------------------------------------------
rem Batch build of WSClientWin2_sample.
rem --------------------------------------------------
%BUILDFILEPATH% %COMMANDLINE% "Samples\WS_sample\WSClient_sample\WSClientWin2_sample\WSClientWin2_sample.sln"

pause

rem --------------------------------------------------
rem Batch build of WSClientWinCone_sample.
rem --------------------------------------------------
%BUILDFILEPATH% %COMMANDLINE% "Samples\WS_sample\WSClient_sample\WSClientWinCone_sample\WSClientWinCone_sample.sln"

pause

rem -------------------------------------------------------
endlocal
