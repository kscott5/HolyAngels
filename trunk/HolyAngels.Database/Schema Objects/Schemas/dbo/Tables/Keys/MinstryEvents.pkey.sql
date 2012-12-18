ALTER TABLE dbo.MinistryEvents ADD CONSTRAINT PK_MinistryEvents
PRIMARY KEY CLUSTERED 	
(	
	[MinistryId] ASC,
	[EventId] ASC
)

GO

ALTER TABLE [dbo].[MinistryEvents]
	ADD CONSTRAINT [FK_MinistryEvents_Ministries] 
	FOREIGN KEY (MinistryId)
	REFERENCES dbo.Ministries (Id)	

GO

ALTER TABLE [dbo].[MinistryEvents]
	ADD CONSTRAINT [FK_MinistryEvents_Events] 
	FOREIGN KEY (EventId)
	REFERENCES dbo.[Events] (Id)	

GO