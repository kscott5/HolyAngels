CREATE TABLE [dbo].[Events]
(
	Id int identity(1,1) NOT NULL, 
	IdKey uniqueidentifier default(newid()) NOT NULL,
	Title nvarchar(100) NOT NULL,
	Description nvarchar(1000) NULL,
	Location nvarchar(500) NOT NULL,
	Speakers nvarchar(500) NULL,
	Created smalldatetime NOT NULL,
	Modified smalldatetime NULL,
	Start smalldatetime NOT NULL,
	[End] smalldatetime NOT NULL,
	Approved bit default(0) NULL
)
