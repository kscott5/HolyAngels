CREATE TABLE [dbo].[Roles]
(
	Id int identity(1,1) NOT NULL, 
	IdKey uniqueidentifier default(newid()) NOT NULL,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(200) NULL,
	Created smalldatetime default(getdate()) NOT NULL,
	Modified smalldatetime NULL
)
