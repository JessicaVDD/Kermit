CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(500) NULL, 
    [LastName] VARCHAR(1000) NULL, 
    [MiddleName] VARCHAR(1000) NULL, 
    [BirthDate] DATE NULL, 
    [BirthPlace] INT NULL, 
    [Nationality] INT NULL, 
    [Sex] CHAR NULL, 
    [IdentityCard] VARCHAR(100) NULL, 
    [NationalRegister] VARCHAR(100) NULL, 
    [PTABegin] DATETIME NOT NULL, 
    [PTAEnd] DATETIME NULL, 
    CONSTRAINT [FK_Person_To_Country] FOREIGN KEY ([Nationality]) REFERENCES [Country]([Id]), 
    CONSTRAINT [FK_Person_To_City] FOREIGN KEY ([BirthPlace]) REFERENCES [City]([Id]), 
    CONSTRAINT [CK_Person_Sex] CHECK (Sex IN ('M','V'))
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'PTA Candidate',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Person',
    @level2type = NULL,
    @level2name = NULL