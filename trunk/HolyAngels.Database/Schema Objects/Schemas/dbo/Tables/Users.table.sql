CREATE TABLE [dbo].[Users]
(
	Id int identity(1,1) NOT NULL, 
	IdKey uniqueidentifier default(newid()) NOT NULL,
	FacebookId int default(-1) NOT NULL,
	AccessToken nvarchar(500) NULL,
	ScreenName nvarchar(50) NOT NULL,
	FirstName nvarchar(50) NULL,
	LastName nvarchar(50) NULL,
	Link nvarchar(200) NULL,
	Email nvarchar(50) NOT NULL,
	Created smalldatetime NOT NULL,
	Modified smalldatetime NULL,
	LastAccessed smalldatetime NULL,
	UserStatus int NOT NULL,
	Birthdate smalldatetime NULL,
	Phone nvarchar(10) NULL,
	PhoneType smallint NULL,
	Street nvarchar(50) NULL,
	[State] int NULL,
	City nvarchar(50) NULL,
	Zipcode nvarchar(10) NULL
)
