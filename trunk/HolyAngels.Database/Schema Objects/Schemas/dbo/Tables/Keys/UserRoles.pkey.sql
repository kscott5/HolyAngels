ALTER TABLE dbo.UserRoles ADD CONSTRAINT [PK_UserRoles]
PRIMARY KEY CLUSTERED 	
(	
	[UserId] ASC,
	[RoleId] ASC
)

GO

ALTER TABLE [dbo].[UserRoles]
	ADD CONSTRAINT [FK_UserRoles_Users] 
	FOREIGN KEY (UserId)
	REFERENCES dbo.Users (Id)	

GO

ALTER TABLE [dbo].[UserRoles]
	ADD CONSTRAINT [FK_UserRoles_Roles] 
	FOREIGN KEY (RoleId)
	REFERENCES dbo.Roles (Id)	

GO