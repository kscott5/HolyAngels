CREATE TABLE [dbo].[Ministries]
(
	Id int identity(1,1) NOT NULL, 
	IdKey uniqueidentifier default(newid()) NOT NULL,
	Name nvarchar(100) NOT NULL,
	Description nvarchar(500) NULL,
	Created smalldatetime default(getdate()) NOT NULL,
	Modified smalldatetime NULL
)
