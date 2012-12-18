ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [HolyAngels], FILENAME = '$(DefaultDataPath)$(DatabaseName).mdf', FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];

