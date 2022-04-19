param (
    [Parameter(Mandatory = $true, HelpMessage = "Specify the host. This is the name of the server and host.")] [String]$S
)

sqlcmd -S $S -E -i ".\create-database.sql"
sqlcmd -S $S -E -i ".\create-procedures.sql"
sqlcmd -S $S -E -i ".\insert-data.sql"
