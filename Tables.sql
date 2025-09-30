-- ==========================
-- Buysell Database Schema
-- ==========================

USE BuysellDB;
GO

-- 1. Profile Types
CREATE TABLE ProfileTypes (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255) NULL
);

-- 2. Profiles
CREATE TABLE Profiles (
    Id INT PRIMARY KEY,
    ProfileTypeId INT NOT NULL,
    DisplayName NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_Profiles_ProfileTypes FOREIGN KEY (ProfileTypeId)
        REFERENCES ProfileTypes(Id)
);

-- 3. Users
CREATE TABLE Users (
    Id INT PRIMARY KEY,
    KeycloakId NVARCHAR(100) NOT NULL UNIQUE,
    Email NVARCHAR(100) NULL,
    CreatedAt DATETIME2 DEFAULT SYSUTCDATETIME(),
    LastLogin DATETIME2 NULL,
    ProfileId INT NOT NULL,
    CONSTRAINT FK_Users_Profiles FOREIGN KEY (ProfileId)
        REFERENCES Profiles(Id)
);

-- 4. Products
CREATE TABLE Products (
    Id INT PRIMARY KEY,
    OwnerId INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    Price DECIMAL(10,2) NOT NULL,
    Status TINYINT,
    CreatedAt DATETIME2 DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_Products_Profiles FOREIGN KEY (OwnerId)
        REFERENCES Profiles(Id)
);

-- 5. Orders
CREATE TABLE Orders (
    Id INT PRIMARY KEY,
    BuyerId INT NOT NULL,
    ProductId INT NOT NULL,
    Status TINYINT,
    CreatedAt DATETIME2 DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_Orders_Users FOREIGN KEY (BuyerId)
        REFERENCES Users(Id),
    CONSTRAINT FK_Orders_Products FOREIGN KEY (ProductId)
        REFERENCES Products(Id)
);
