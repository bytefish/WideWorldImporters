USE [WideWorldImporters]
GO

CREATE LOGIN wwi WITH PASSWORD = N'340$Uuxwp7Mcxo7Khy'
GO

CREATE USER wwi FOR LOGIN wwi
GO

EXEC sp_addrolemember N'db_datareader', N'wwi'
GO

EXEC sp_addrolemember N'db_datawriter', N'wwi'
GO