CREATE TABLE [dbo].[FamilyAddress]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Family] INT NOT NULL, 
    [Address] INT NOT NULL, 
    [PTABegin] DATETIME NOT NULL, 
    [PTAEnd] DATETIME NULL, 
    CONSTRAINT [FK_FamilyAddress_ToFamily] FOREIGN KEY (Family) REFERENCES [Family]([Id]),
    CONSTRAINT [FK_FamilyAddress_ToAddress] FOREIGN KEY (Address) REFERENCES [Address]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'PTA Candidate',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'FamilyAddress',
    @level2type = NULL,
    @level2name = NULL
