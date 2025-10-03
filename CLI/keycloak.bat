SET SERVER_NAME=localhost

sqlcmd -S %SERVER_NAME% -E -i "..\Database\Keycloak.sql"