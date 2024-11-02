# Database Setup
function dbs {
    $migrations_dir = ".\Armoire\Migrations"
    $db_path = "$($env:localappdata)\ArmoireData.db"

    Remove-Item -r -fo $migrations_dir
    Remove-Item $db_path

    dotnet ef migrations add InitialCreate --project .\Armoire\Armoire.csproj
    dotnet ef database update --project .\Armoire\Armoire.csproj
}

# Delete Logs
function dl {
    $logs_path = "$($env:appdata)\ArmoireDebugOutput*"

    Remove-Item $logs_path
}

# Run All
function ra {
    dbs
    dl
}