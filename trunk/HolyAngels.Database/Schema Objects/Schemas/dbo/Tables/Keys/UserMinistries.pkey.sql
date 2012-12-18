ALTER TABLE dbo.UserMinistries ADD CONSTRAINT PK_UserMinistries
PRIMARY KEY CLUSTERED 	
(	
	[UserId] ASC,
	[MinistryId] ASC
)

GO

ALTER TABLE [dbo].[UserMinistries]
	ADD CONSTRAINT [FK_UserMinistries_Users] 
	FOREIGN KEY (UserId)
	REFERENCES dbo.Users (Id)	

GO

ALTER TABLE [dbo].[UserMinistries]
	ADD CONSTRAINT [FK_UserMinistries_Roles] 
	FOREIGN KEY (MinistryId)
	REFERENCES dbo.Ministries (Id)	

GO