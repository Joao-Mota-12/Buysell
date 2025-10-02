SET SERVER_NAME=localhost

sqlcmd -S %SERVER_NAME% -i "..\Database\Database.sql"

sqlcmd -S %SERVER_NAME% -E -i "..\Database\Tables.sql"

sqlcmd -S %SERVER_NAME% -E -i "..\Database\Data.sql"

echo All scripts executed successfully!
