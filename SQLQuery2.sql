CREATE DATABASE AccountingDB;
Go

USE AccountingDB;
Go

CREATE TABLE Users
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Username] NVARCHAR (100) NOT NULL,
	[Password] NVARCHAR (100) NOT NULL,
	[RegisterDate] DATETIME NOT NULL
);
GO
