ALTER TABLE dbo.MinistryCategories ADD CONSTRAINT PK_MinistryCategories
PRIMARY KEY CLUSTERED 	
(	
	[MinistryId] ASC,
	[CategoryId] ASC
)

GO

ALTER TABLE [dbo].[MinistryCategories]
	ADD CONSTRAINT [FK_MinistryCategories_Ministries] 
	FOREIGN KEY (MinistryId)
	REFERENCES dbo.Ministries (Id)	

GO

ALTER TABLE [dbo].[MinistryCategories]
	ADD CONSTRAINT [FK_MinistryCategories_Categories] 
	FOREIGN KEY (CategoryId)
	REFERENCES dbo.Categories (Id)	

GO