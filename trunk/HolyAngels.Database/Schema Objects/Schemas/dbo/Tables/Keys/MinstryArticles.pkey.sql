ALTER TABLE dbo.MinistryArticles ADD CONSTRAINT PK_MinistryArticles
PRIMARY KEY CLUSTERED 	
(	
	[MinistryId] ASC,
	[ArticleId] ASC
)

GO

ALTER TABLE [dbo].[MinistryArticles]
	ADD CONSTRAINT [FK_MinistryArticles_Ministries] 
	FOREIGN KEY (MinistryId)
	REFERENCES dbo.Ministries (Id)	

GO

ALTER TABLE [dbo].[MinistryArticles]
	ADD CONSTRAINT [FK_MinistryArticles_Articles] 
	FOREIGN KEY (ArticleId)
	REFERENCES dbo.Articles (Id)	

GO