/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/*
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'HADBA')
	DROP LOGIN HADBA
GO

CREATE LOGIN HADBA	WITH PASSWORD = 'H01y@ng31sMvcWeb', DEFAULT_DATABASE=[HolyAngels]
GO

IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'HAAdmin')
	DROP USER [HAAdmin]
GO

CREATE USER [HAAdmin] FOR LOGIN [HADBA] WITH DEFAULT_SCHEMA=[dbo]
GO

--GRANT CONTROL ON ROLE :: db_owner TO HAAdmin WITH GRANT OPTION
--GO
*/

if not exists(select * from dbo.Categories where Id = 1)
begin
set identity_insert dbo.Categories on

insert into Categories (Id,TypeId,Name,Description,Created) values (1,1,'Catechesis','Oral instruction of the Catholic Church doctrine or faith.',GETDATE())
insert into Categories (Id,TypeId,Name,Description,Created) values (2,1,'Technology','',GETDATE())
insert into Categories (Id,TypeId,Name,Description,Created) values (3,1,'Youth','',GETDATE())
insert into Categories (Id,TypeId,Name,Description,Created) values (4,1,'Women','',GETDATE())
insert into Categories (Id,TypeId,Name,Description,Created) values (5,1,'Men','',GETDATE())
insert into Categories (Id,TypeId,Name,Description,Created) values (6,1,'Music','',GETDATE())
insert into Categories (Id,TypeId,Name,Description,Created) values (7,1,'Service','',GETDATE())
insert into Categories (Id,TypeId,Name,Description,Created) values (8,1,'Evangelization','',GETDATE())
insert into Categories (Id,TypeId,Name,Description,Created) values (9,1,'Health & Wellness','',GETDATE())

set identity_insert dbo.Categories off
end

if not exists(select * from dbo.Ministries where Id = 1)
begin
	set identity_insert dbo.Ministries on
	insert into Ministries (Id, Name, Description) values (1, 'Baptism','')
	insert into Ministries (Id, Name, Description) values (2, 'Holy Communion', '')
	insert into Ministries (Id, Name, Description) values (3, 'Confirmation', '')
	insert into Ministries (Id, Name, Description) values (4, 'Weddings', '')
	insert into Ministries (Id, Name, Description) values (5, 'Children''s Ministry of the Word', '')
	insert into Ministries (Id, Name, Description) values (6, 'Vacation Bible School', '')
	insert into Ministries (Id, Name, Description) values (7, 'Holy Angels''s Angels - Youth Choir', '')
	insert into Ministries (Id, Name, Description) values (8, 'Blessed Sacrament Society', '')
	insert into Ministries (Id, Name, Description) values (9, 'Ladies Volunteers', '')
	insert into Ministries (Id, Name, Description) values (10, 'Ladies of St. Peter Claver', '')
	insert into Ministries (Id, Name, Description) values (11, 'Red Hat Society', '')
	insert into Ministries (Id, Name, Description) values (12, 'Men''s Coalition', '')
	insert into Ministries (Id, Name, Description) values (13, 'Knights of St. Peter Claver', '')
	insert into Ministries (Id, Name, Description) values (14, 'Holy Angels Eucharistic Ensemble', '')
	insert into Ministries (Id, Name, Description) values (15, 'Holy Name Society', '')
	insert into Ministries (Id, Name, Description) values (16, 'Bereavement', '')
	insert into Ministries (Id, Name, Description) values (17, 'Ushers and Greets', '')
	insert into Ministries (Id, Name, Description) values (18, 'HIV/AIDS Ministry', '')
	insert into Ministries (Id, Name, Description) values (19, 'Healthy Side Chats', '')
	insert into Ministries (Id, Name, Description) values (20, 'Technology Ministry', '')
	set identity_insert dbo.Ministries off
end

if not exists(select * from dbo.MinistryCategories where MinistryId = 1 and CategoryId = 1)
begin
	insert into MinistryCategories (CategoryId, MinistryId) values (1,1)
	insert into MinistryCategories (CategoryId, MinistryId) values (1,2)
	insert into MinistryCategories (CategoryId, MinistryId) values (1,3)
	insert into MinistryCategories (CategoryId, MinistryId) values (1,4)

	insert into MinistryCategories (CategoryId, MinistryId) values (2,20)

	insert into MinistryCategories (CategoryId, MinistryId) values (3,5)
	insert into MinistryCategories (CategoryId, MinistryId) values (3,6)
	insert into MinistryCategories (CategoryId, MinistryId) values (3,7)

	insert into MinistryCategories (CategoryId, MinistryId) values (4,8)
	insert into MinistryCategories (CategoryId, MinistryId) values (4,9)
	insert into MinistryCategories (CategoryId, MinistryId) values (4,10)
	insert into MinistryCategories (CategoryId, MinistryId) values (4,11)

	insert into MinistryCategories (CategoryId, MinistryId) values (5,12)
	insert into MinistryCategories (CategoryId, MinistryId) values (5,13)

	insert into MinistryCategories (CategoryId, MinistryId) values (6,14)
	insert into MinistryCategories (CategoryId, MinistryId) values (6,7)

	insert into MinistryCategories (CategoryId, MinistryId) values (7,15)
	insert into MinistryCategories (CategoryId, MinistryId) values (7,8)
	insert into MinistryCategories (CategoryId, MinistryId) values (7,13)
	insert into MinistryCategories (CategoryId, MinistryId) values (7,10)
	insert into MinistryCategories (CategoryId, MinistryId) values (7,16)

	insert into MinistryCategories (CategoryId, MinistryId) values (8,17)

	insert into MinistryCategories (CategoryId, MinistryId) values (9,18)
	insert into MinistryCategories (CategoryId, MinistryId) values (9,19)
end

if not exists(select * from dbo.Quotes where id = 1)
begin
	set identity_insert dbo.Quotes on
	insert into dbo.Quotes (Id, [Description], [Source], [Approved]) values (1, 'I am the Alpha and the Omega, says the Lord God, who is, who was, and who is to come, the Almighty.', 'Revelation 1:8', 1)
	insert into dbo.Quotes (Id, [Description], [Source], [Approved]) values (2, 'You are worthy, our Lord and God, to receive glory and honour and power, for you made the whole universe; by your will, when it did not exist, it was created.', 'Revelation 4:11', 1)
	insert into dbo.Quotes (Id, [Description], [Source], [Approved]) values (3, 'Father, may your name be held holy, your kingdom come; give us each day our daily bread, and forgive us or sins, for we ourselves forgive each one who is in debt to us. And do not put us to the test.', 'Luke 11:1', 1)
	insert into dbo.Quotes (Id, [Description], [Source], [Approved]) values (4, 'Rejoice, you who enjoy God''s favor!...Look! You are to conceive in your womb and bear a son, and you must name him Jesus. He will be great and will be called Son of the Most High', 'Luke 1:39', 1)
	insert into dbo.Quotes (Id, [Description], [Source], [Approved]) values (5, 'May God Bless You and Keep You. May God''s Perpetual Light Shine Upon You. In the Name of the Father, Son, And Holy Spirit.', 'Holy Angels Church', 1)
	insert into dbo.Quotes (Id, [Description], [Source], [Approved]) values (6, 'Why this uproar among the nations, this impotent muttering of the peoples? Kings on earth take up position, princes plot together against the Lord and his Anointed.', 'Acts 4:37', 1)
	insert into dbo.Quotes (Id, [Description], [Source], [Approved]) values (7, '...the Lord took some bread, and after he had given thanks, he broke it, and he said, ''This is my body, which is for you, do this in remembrance of me.'' And in the same way, with the cup after supper, saying, This cup is the new covenant in my blood. Whenever you drink it, do this as a memorial of me. Whenever you eat this bread, then and drink this cup, you are proclaiming the Lord''s death until he comes. Therefore anyone who eats the bread or drinks the cup of the Lord unworthily is answerable for the body and blood of the Lord.', 'Corinthians 11:27', 1)

	set identity_insert dbo.Quotes off
end

if not exists(select * from dbo.Roles where id = 1)
begin
	set identity_insert dbo.Roles on
	insert into dbo.Roles (Id, [Name], [Description]) values (1, 'Basic', '')
	insert into dbo.Roles (Id, [Name], [Description]) values (2, 'Administrator', '')
	insert into dbo.Roles (Id, [Name], [Description]) values (3, 'Ministry', '')
	insert into dbo.Roles (Id, [Name], [Description]) values (4, 'Content Publisher', '')
	insert into dbo.Roles (Id, [Name], [Description]) values (5, 'Content Approver', '')
	set identity_insert dbo.Roles off
end
