CREATE TABLE [dbo].[Family]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(500) NULL,
    [PTABegin] DATETIME NOT NULL, 
    [PTAEnd] DATETIME NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'PTA Candidate',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Family',
    @level2type = NULL,
    @level2name = NULL