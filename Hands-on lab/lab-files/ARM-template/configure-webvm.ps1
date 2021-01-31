param (
    [Parameter(Mandatory=$False)] [string] $SqlIP = ""
)
function Disable-InternetExplorerESC {
    $AdminKey = "HKLM:\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A7-37EF-4b3f-8CFC-4F3A74704073}"
    $UserKey = "HKLM:\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A8-37EF-4b3f-8CFC-4F3A74704073}"
    Set-ItemProperty -Path $AdminKey -Name "IsInstalled" -Value 0 -Force
    Set-ItemProperty -Path $UserKey -Name "IsInstalled" -Value 0 -Force
    Stop-Process -Name Explorer -Force
    Write-Host "IE Enhanced Security Configuration (ESC) has been disabled." -ForegroundColor Green
}

# To resolve the error of https://github.com/microsoft/MCW-App-modernization/issues/68. The cause of the error is Powershell by default uses TLS 1.0 to connect to website, but website security requires TLS 1.2. You can change this behavior with running any of the below command to use all protocols. You can also specify single protocol.
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls, [Net.SecurityProtocolType]::Tls11, [Net.SecurityProtocolType]::Tls12, [Net.SecurityProtocolType]::Ssl3
[Net.ServicePointManager]::SecurityProtocol = "Tls, Tls11, Tls12, Ssl3"

# Disable IE ESC
Disable-InternetExplorerESC

Install-WindowsFeature -name Web-Server -IncludeManagementTools

$branchName = "2021updates"

# Download and extract the starter solution files
Invoke-WebRequest "https://github.com/microsoft/MCW-App-modernization/archive/$branchName.zip" -OutFile 'C:\MCW.zip'
Expand-Archive -LiteralPath 'C:\MCW.zip' -DestinationPath 'C:\MCW' -Force

# Copy Web Site Files
Expand-Archive -LiteralPath "C:\MCW\MCW-App-modernization-$branchName\Hands-on lab\lab-files\web-site-publish.zip" -DestinationPath 'C:\inetpub\wwwroot' -Force

# Replace SQL Connection String
((Get-Content -path C:\inetpub\wwwroot\config.release.json -Raw) -replace 'SETCONNECTIONSTRING',"Server=$SqlIP;Database=PartsUnlimited;User Id=PUWebSite;Password=r2gafWdLY7zwi7YbJqUs9@W33W6UY9;") | Set-Content -Path C:\inetpub\wwwroot\config.json

# Download and install .NET Core 2.2
Invoke-WebRequest 'https://download.visualstudio.microsoft.com/download/pr/5efd5ee8-4df6-4b99-9feb-87250f1cd09f/552f4b0b0340e447bab2f38331f833c5/dotnet-hosting-2.2.2-win.exe' -OutFile 'C:\dotnet-hosting-2.2.2-win.exe'
$pathArgs = {C:\dotnet-hosting-2.2.2-win.exe /Install /Quiet /Norestart /Logs log.txt}
Invoke-Command -ScriptBlock $pathArgs

# Download and install SQL Server Management Studio
Invoke-WebRequest 'https://aka.ms/ssmsfullsetup' -OutFile 'C:\SSMS-Setup.exe'
$pathArgs = {C:\SSMS-Setup.exe /Install /Quiet /Norestart /Logs log.txt}
Invoke-Command -ScriptBlock $pathArgs


https://raw.githubusercontent.com/microsoft/MCW-App-modernization/2021updates/Hands-on%20lab/lab-files/src/src/PartsUnlimitedWebsite/config.release.json