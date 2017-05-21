REM @ECHO OFF

REM IMPORTANT NOTE: Open Cover uses pdbs to get code coverage for nunit tests.
REM Therefore there is an issue that the pdb path information built into the binary does not correspond to local paths.
REM This will prevent the coverage from running.
REM The solution is to ensure you have built locally first, before running coverage and generating the report.

REM Constant declarations
set openCoverConsole="%~dp0..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe"
set nunitConsole="%~dp0..\..\packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe"
set namespacePrefix="ChessWithTDD.Tests."
set whitePawn="WhitePawn"
set blackPawn="BlackPawn"
set knight="Knight"
set whitePawnTests="WhitePawnTests"
set blackPawnTests="BlackPawnTests"
set knightTests="KnightTests"

set openCoverReportsFolder="%~dp0..\..\OpenCoverReports"
set openCoverResultsFolder="%~dp0..\..\OpenCoverResults"
set nunitResultsFolder="%~dp0.\NUnitResults"

REM *** Main entry point ***
call:DeleteFoldersAndContents
call:CreateFolders
call:RunAllTestsInChessObjectLibrary
pause
call:RunReportGeneratorForEverything
pause
call:RunLaunchReport
GOTO:EOF
REM *** The End ***

REM *** Main entry point ***
REM call:DeleteFoldersAndContents
REM call:CreateFolders
REM call:RunOpenCoverUnitTestMetrics
REM call:RunLaunchReports
REM GOTO:EOF
REM *** The End ***

:RunAllTestsInChessObjectLibrary
%openCoverConsole% ^
-target:%nunitConsole% ^
-register:user ^
-targetargs:"%~dp0..\bin\Debug\ChessWithTDD.dll --work=%nunitResultsFolder%" ^
-filter:"+[ChessWithTDD*]* -[ChessWithTDD.Tests]*" ^
-output:"%openCoverResultsFolder%\oc_AllChessObjectLibraryClasses_results.xml" ^
-searchdirs:"%~dp0..\bin\Debug"
GOTO:EOF

:RunReportGeneratorForEverything
ECHO ON
ECHO %openCoverResultsFolder%\ooc_AllChessObjectLibraryClasses_results.xml
"%~dp0..\..\packages\ReportGenerator.2.5.5\tools\ReportGenerator.exe" ^
-targetdir:"%openCoverReportsFolder%\ReportForEverything" ^
-reports:"%openCoverResultsFolder%\oc_AllChessObjectLibraryClasses_results.xml" 
GOTO:EOF

:RunLaunchReport
start "Test coverage report" "%openCoverReportsFolder%\ReportForEverything\index.htm"
GOTO:EOF

REM ------------------------------------------------------------------------
REM nothing below this point is run currently, running tests for everything
REM ------------------------------------------------------------------------

:DeleteFoldersAndContents
if exist %openCoverReportsFolder% rmdir %openCoverReportsFolder% /s /q 
if exist %openCoverResultsFolder% rmdir %openCoverResultsFolder% /s /q
if exist %nunitResultsFolder% rmdir %nunitResultsFolder% /s /q
GOTO:EOF

:CreateFolders
mkdir %openCoverReportsFolder%
mkdir %openCoverResultsFolder%
mkdir %nunitResultsFolder%
GOTO:EOF

:RunOpenCoverUnitTestMetrics
call:RunSpecificTestFixture %blackPawnTests% %blackPawn%
call:RunSpecificTestFixture %whitePawnTests% %whitePawn%
call:RunSpecificTestFixture %knightTests% %knight%
call:RunReportGeneratorFromOpenCoverResults %whitePawnTests% 
call:RunReportGeneratorFromOpenCoverResults %blackPawnTests%
call:RunReportGeneratorFromOpenCoverResults %knightTests%
GOTO:EOF

:RunLaunchReports
call:RunLaunchReport %whitePawnTests%
call:RunLaunchReport %blackPawnTests%
call:RunLaunchReport %knightTests%
GOTO:EOF

:RunSpecificTestFixture
:: -- %~1 - name of test fixture
:: -- %~2 - name of test piece class to add in report. Always include parents Piece class
%openCoverConsole% ^
-target:%nunitConsole% ^
-register:user ^
-filter:"-[ChessWithTDD.*]* +[ChessWithTDD]ChessWithTDD.Piece +[ChessWithTDD]ChessWithTDD.%~2" ^
-targetargs:"%~dp0..\bin\Debug\ChessWithTDD.dll --where \"class == %namespacePrefix%%~1\" --work=%nunitResultsFolder%" ^
-output:"%openCoverResultsFolder%\oc_"%~1"_results.xml" ^
-searchdirs:"%~dp0..\bin\Debug"
GOTO:EOF

:RunReportGeneratorFromOpenCoverResults
:: -- %~1 - report 1
ECHO ON
ECHO %openCoverResultsFolder%\oc_%~1_results.xml
"%~dp0..\..\packages\ReportGenerator.2.5.5\tools\ReportGenerator.exe" ^
-targetdir:"%openCoverReportsFolder%\%~1" ^
-reports:"%openCoverResultsFolder%\oc_%~1_results.xml" 
GOTO:EOF

:RunLaunchReport
:: -- %~1 - report 1
start "Test coverage report" "%openCoverReportsFolder%\%~1\index.htm"
GOTO:EOF