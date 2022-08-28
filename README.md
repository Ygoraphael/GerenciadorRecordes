# Manager-record-Express

if you don't have the command dotnet installed run the code bellow on power shell
dotnet tool install --global dotnet-ef 2>$null

command to create files with changes of the project reflect on database
dotnet ef migrations name

command to run migrations on database
dotnet ef database update