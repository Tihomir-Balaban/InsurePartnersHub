USE [DB_NAME_HERE]

CREATE TABLE Partners (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(MAX),
    PartnerNumber BIGINT NOT NULL,
    CroatianPIN NVARCHAR(11),
    PartnerTypeId INT NOT NULL,
    CreatedAtUtc DATETIME NOT NULL,
    CreateByUser NVARCHAR(255) NOT NULL,
    IsForeign BIT NOT NULL,
    ExternalCode NVARCHAR(20) NOT NULL UNIQUE,
    Gender CHAR(1) NOT NULL CHECK (Gender IN ('M', 'F', 'N'))
);

CREATE TABLE Policies (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ShelfNumber NVARCHAR(15) NOT NULL,
    PolicyAmount DECIMAL(18, 2) NOT NULL,
    PartnerId INT NOT NULL FOREIGN KEY REFERENCES Partners(Id)
);
