-- ==========================
-- Mock Data for BuysellDB
-- ==========================

USE BuysellDB;
GO

-- 1. ProfileTypes
INSERT INTO ProfileTypes (Id, Name, Description) VALUES (1,'Buyer', 'Can browse and buy products');
INSERT INTO ProfileTypes (Id, Name, Description) VALUES (2,'Seller', 'Can list and sell products');
INSERT INTO ProfileTypes (Id, Name, Description) VALUES (3,'Admin', 'Full access to the platform');

-- 2. Profiles
INSERT INTO Profiles (Id, ProfileTypeId, DisplayName) VALUES (1, 3, 'Admin');
INSERT INTO Profiles (Id, ProfileTypeId, DisplayName) VALUES(2, 1, 'Buyer1');
INSERT INTO Profiles (Id, ProfileTypeId, DisplayName) VALUES(3, 1, 'Buyer2');
INSERT INTO Profiles (Id, ProfileTypeId, DisplayName) VALUES(4, 2, 'Seller1');

-- 3. Users
INSERT INTO Users (Id, KeycloakId, Email, ProfileId) VALUES (1, 'keycloak-user-1', 'joao.mota@test.com', 1);
INSERT INTO Users (Id, KeycloakId, Email, ProfileId) VALUES (2, 'keycloak-user-2', 'bob@test.com', 2);
INSERT INTO Users (Id, KeycloakId, Email, ProfileId) VALUES (3, 'keycloak-user-3', 'john@test.com', 3);
INSERT INTO Users (Id, KeycloakId, Email, ProfileId) VALUES (4, 'keycloak-user-4', 'admin@test.com', 4);

-- 4. Products
INSERT INTO Products (Id,OwnerId, Name, Description, Price, Status) VALUES (1,4, 'Laptop', 'Gaming Laptop', 1500.00, 0); 

INSERT INTO Products (Id,OwnerId, Name, Description, Price, Status) VALUES (2,4, 'Shirt', 'Sports Shirt', 25.00, 0);

-- 5. Orders
INSERT INTO Orders (Id, BuyerId, ProductId, Status) VALUES(1, 1, 1, 0);