call RunOpenCoverUnitTestMetrics
call RunReportGeneratorFromOpenCoverResults

:RunOpenCoverUnitTestMetrics
"%~dp0..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-target:"%~dp0..\..\packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe" ^
-register:user "-filter:+[ChessWithTDD]* -[ChessWithTDD]ChessWithTDD.Tests.*" ^
-targetargs:"%~dp0..\bin\Debug\ChessWithTDD.dll" ^
-output:"%~dp0..\..\open_cover_results.xml" ^
-searchdirs:"%~dp0..\bin\Debug"

:RunReportGeneratorFromOpenCoverResults
"%~dp0..\..\packages\ReportGenerator.2.5.5\tools\ReportGenerator.exe" ^
-targetdir:"%~dp0..\..\OpenCoverReport" ^
-reports:"%~dp0..\..\open_cover_results.xml" ^ 

:RunLaunchReport
start "Test coverage report" "%~dp0..\..\OpenCoverReport\index.htm"