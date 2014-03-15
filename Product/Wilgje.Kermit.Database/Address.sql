CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Adressee] VARCHAR(1000) NULL, 
    [Street] INT NULL, 
    [NumberAndBus] VARCHAR(50) NULL, 
    [PTABegin] DATETIME NOT NULL, 
    [PTAEnd] DATETIME NULL,
	CONSTRAINT [FK_Address_To_Street] FOREIGN KEY ([Street]) REFERENCES [Street]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'PTA Candidate',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Address',
    @level2type = NULL,
    @level2name = NULL
