ALTER TABLE [dbo].[Users] ADD CONSTRAINT [UK_UsersEmail] UNIQUE (Email)
GO
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [UK_UsersScreen] UNIQUE (ScreenName)
GO