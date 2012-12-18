CREATE TABLE [dbo].[Articles]
(
	Id int identity(1,1) NOT NULL, 
	IdKey uniqueidentifier default(newid()) NOT NULL,
	Title nvarchar(50) NOT NULL,
	CategoryId int NOT NULL,
	Description nvarchar(max) NOT NULL,
	Summary nvarchar(1000) NOT NULL,
	Keywords nvarchar(500) NULL,
	Author nvarchar(100) NOT NULL,
	Created smalldatetime NOT NULL,
	Modified smalldatetime NOT NULL,
	Start smalldatetime NOT NULL,
	[End] smalldatetime NOT NULL,
	Approved bit default(0) NULL
)
