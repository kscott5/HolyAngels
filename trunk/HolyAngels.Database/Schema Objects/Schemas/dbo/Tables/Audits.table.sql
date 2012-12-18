CREATE TABLE [dbo].[Audits]
(
	Id int identity(1,1) NOT NULL, 
	UserIdKey uniqueidentifier NOT NULL,
	AuditType smallint NOT NULL,
	Description nvarchar(500) NOT NULL,
	Created smalldatetime NOT NULL,
	Modified smalldatetime NULL
)
