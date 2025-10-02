-- ==========================
-- Buysell Database Creation
-- ==========================

-- 1. Create the database
CREATE DATABASE BuysellDB;
GO

-- 2. Create User

USE BuysellDB;
GO

IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'buysell_user')
BEGIN
    CREATE LOGIN buysell_user
    WITH PASSWORD = 'Passw0rd', 
    CHECK_POLICY = OFF,
    CHECK_EXPIRATION = OFF;
END
ELSE
BEGIN
    PRINT 'Login buysell_user already exists.';
END
GO

IF IS_SRVROLEMEMBER('dbcreator', 'buysell_user') = 0
BEGIN
    ALTER SERVER ROLE dbcreator ADD MEMBER buysell_user;
    PRINT 'Granted dbcreator role to buysell_user.';
END
GO

CREATE USER buysell_user FOR LOGIN buysell_user;
GO

ALTER ROLE db_owner ADD MEMBER buysell_user;
GO
