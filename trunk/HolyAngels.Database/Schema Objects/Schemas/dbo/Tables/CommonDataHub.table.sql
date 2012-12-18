CREATE TABLE [dbo].[CommonDataHub]
(
	Id int identity(1,1) NOT NULL, 
	IdKey uniqueidentifier default(newid()) NOT NULL,
	CountryName nvarchar(200) NOT NULL,
	SubdivisionStateName nvarchar(200) NOT NULL, 
	PrimaryLevelName nvarchar(200) NULL,
	SubdivisionCDHID int NOT NULL,	
	CountryCDHID int NOT NULL,
	CountryISOChar2Code	char(2) NOT NULL,
	CountryISOChar3Code char(3) NOT NULL,
	Created smalldatetime default(getdate()) NOT NULL,
	Modifed smalldatetime NULL
)
