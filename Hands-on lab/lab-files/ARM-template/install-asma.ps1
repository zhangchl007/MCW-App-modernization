Write-Host "App Service Migration Assistant is now installing..."
Start-Process -file 'C:\AppServiceMigrationAssistant.msi ' -arg '/qn /l*v C:\asma_install.txt' -passthru | wait-process
Unregister-ScheduledTask -TaskName "Install App Service Migration Assistant" -Confirm:$false