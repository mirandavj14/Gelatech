GO
CREATE DATABASE GelatechDB;
GO
USE GelatechDB;
GO
CREATE TABLE [Role]
(
Id INT IDENTITY(1,1) NOT NULL,
Name VARCHAR(100),
Description VARCHAR(200),
PRIMARY KEY (Id)
);
GO
CREATE TABLE [User]
(
Id INT IDENTITY(1,1) NOT NULL,
Name VARCHAR(80),
Username VARCHAR(100),
Password VARCHAR(25),
RoleId INT,
PRIMARY KEY (Id),
FOREIGN KEY (RoleId) REFERENCES [Role](Id)
);
GO
CREATE TABLE [Product]
(
Id INT IDENTITY(1,1) NOT NULL,
Name VARCHAR(80),
Description VARCHAR(200),
Price DECIMAL(15,2),
PRIMARY KEY (Id)
);
GO
CREATE TABLE [Invoice]
(
Id INT IDENTITY(1,1) NOT NULL,
Date DATETIME,
Payment VARCHAR(100),
Taxes DECIMAL(15,2),
Discount DECIMAL(15,2),
SubTotal DECIMAL(15,2),
Total DECIMAL(15,2),
PRIMARY KEY (Id)
)
GO
CREATE TABLE [ProductInvoice]
(
Id INT IDENTITY(1,1) NOT NULL,
ProductId INT NOT NULL,
InvoiceId INT NOT NULL,
Quantity INT NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (ProductId) REFERENCES [Product](Id),
FOREIGN KEY (InvoiceId) REFERENCES [Invoice](Id)
)
GO
/*INSERTS FOR TABLE roles*/
INSERT INTO [Role](name,description) VALUES ('Administrator','has access to all functionalities of the system');
INSERT INTO [Role](name,description) VALUES ('User','uses just the general functionalities of the system');
GO
/*INSERTS FOR TABLE User*/
INSERT INTO [User](Name,Username,Password,RoleId)
VALUES('Vinicio Miranda','miranda.vj','123456',1);
GO
INSERT INTO [User](Name,Username,Password,RoleId)
VALUES('Alana Arias','alana.ar','123456',1);
GO
/*INSERTS FOR TABLE Product*/
INSERT INTO [Product](Name,Description,Price)
VALUES('Papas','caja de papas marca pringles',15.82)
GO
INSERT INTO [Product](Name,Description,Price)
VALUES('Bolis','Bolis de diferentes sabores',15.82)
GO
INSERT INTO [Product](Name,Description,Price)
VALUES('Gelatinas','Gelatinas de fresa',15.82)
GO
INSERT INTO [Product](Name,Description,Price)
VALUES('Coca','Botella de Cola Cola 500 ml',15.82)
GO
INSERT INTO [Product](Name,Description,Price)
VALUES('Agua','Botella de agua de 500 ml',15.82)







