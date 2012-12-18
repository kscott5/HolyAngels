CREATE TABLE [dbo].[Categories]
(
	Id int identity(1,1) NOT NULL, 
	IdKey uniqueidentifier default(newid()) NOT NULL,
	TypeId int NOT NULL,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(200) NULL,
	Created smalldatetime NOT NULL,
	Modified smalldatetime NULL
)
