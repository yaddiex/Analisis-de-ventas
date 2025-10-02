--Crear base de datos
IF DB_ID('SalesAnalytics') IS NULL
BEGIN
CREATE DATABASE SalesAnalytics;
END
GO


USE SalesAnalytics;
GO


-- Tabla Clientes
CREATE TABLE dbo.Clientes (
CustomerID NVARCHAR(50) PRIMARY KEY,
FirstName NVARCHAR(100),
LastName NVARCHAR(100),
Email NVARCHAR(200),
Phone NVARCHAR(50),
City NVARCHAR(100),
Country NVARCHAR(100),
CreatedAt DATETIME2 DEFAULT SYSUTCDATETIME()
);


-- Tabla Productos
CREATE TABLE dbo.Productos (
ProductID NVARCHAR(50) PRIMARY KEY,
ProductName NVARCHAR(200) NOT NULL,
Category NVARCHAR(100),
Price DECIMAL(18,2) DEFAULT 0,
Stock INT DEFAULT 0,
CreatedAt DATETIME2 DEFAULT SYSUTCDATETIME()
);


-- Tabla Ventas (transaccional)
CREATE TABLE dbo.Ventas (
SaleID BIGINT IDENTITY(1,1) PRIMARY KEY,
CustomerID NVARCHAR(50) NOT NULL,
ProductID NVARCHAR(50) NOT NULL,
Quantity INT NOT NULL DEFAULT 1,
Price DECIMAL(18,2) NOT NULL,
Date DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
Total DECIMAL(18,2) NOT NULL,
SourceID INT NULL,
CONSTRAINT FK_Ventas_Clientes FOREIGN KEY (CustomerID) REFERENCES dbo.Clientes(CustomerID),
CONSTRAINT FK_Ventas_Productos FOREIGN KEY (ProductID) REFERENCES dbo.Productos(ProductID)
);


-- Tabla de auditoría / fuente de datos
CREATE TABLE dbo.FuenteDatos (
SourceID INT IDENTITY(1,1) PRIMARY KEY,
SourceType NVARCHAR(50), -- CSV, API, DB
FileName NVARCHAR(260),
LoadDate DATETIME2 DEFAULT SYSUTCDATETIME(),
RowsLoaded INT
);


-- Índices recomendados
CREATE INDEX IX_Ventas_Date ON dbo.Ventas(Date);
CREATE INDEX IX_Ventas_Product ON dbo.Ventas(ProductID);
CREATE INDEX IX_Ventas_Customer ON dbo.Ventas(CustomerID);
GO