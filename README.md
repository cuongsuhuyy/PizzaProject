# PizzaProject

requirement:
- .Net core 6.0
- Entity framework 6.0
- SQL Server

first run:
- change connection string to local db on local computer at appsettings.json
- open package manage console (Tools>Nuget Package Manager>Package Manage Console)
- run "Add-Migration InitialDatabase"
- run "Update-Database"
