devenv /clean debug WebService1.sln
devenv /build debug WebService1.sln
cd Simian\simian-2.5.10\bin
simian-2.5.10.exe *.cs

cd C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow
vstest.console.exe "C:\BootCamp\Case2\WebService\ChatbotLib.Test\bin\Debug\ChatbotLib.Test.dll" /platform:x64 /logger:trx
vstest.console.exe "C:\BootCamp\Case2\WebService\CategoryLib.Test\bin\Debug\CategoryLib.Test.dll" /platform:x64 /logger:trx
vstest.console.exe "C:\BootCamp\Case2\WebService\CustomerDataLib.Test\bin\Debug\CustomerDataLib.Test.dll" /platform:x64 /logger:trx
vstest.console.exe "C:\BootCamp\Case2\WebService\MonitorSalesLib.Test\bin\Debug\MonitorSalesLib.Test.dll" /platform:x64 /logger:trx
vstest.console.exe "C:\BootCamp\Case2\WebService\SalesRepLib.Test\bin\Debug\SalesRepLib.Test.dll" /platform:x64 /logger:trx
pause
