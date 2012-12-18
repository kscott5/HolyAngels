CREATE TABLE [dbo].[Quotes]
(
	Id int identity(1,1) NOT NULL, 
	IdKey uniqueidentifier default(newid()) NOT NULL,
	Description nvarchar(1000) NOT NULL,
	Source nvarchar(100) NOT NULL,
	Created smalldatetime default(getdate()) NOT NULL,
	Modified smalldatetime NULL,
	Approved bit default(0) NULL
)
