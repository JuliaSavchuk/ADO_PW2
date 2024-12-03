Create database StationeryStore

GO

USE StationeryStore;
CREATE TABLE Stationery (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50),
[Type] NVARCHAR(50),
Quantity INT,
Cost DECIMAL(18, 2)
            );

CREATE TABLE Sales (
Id INT PRIMARY KEY IDENTITY,
StationeryId INT FOREIGN KEY REFERENCES Stationery(Id),
Manager NVARCHAR(50),
BuyerCompany NVARCHAR(50),
QuantitySold INT,
PricePerUnit DECIMAL(18, 2),
SaleDate DATE
            );