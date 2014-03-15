CREATE TABLE [dbo].[Child]
(
    [Person] INT NOT NULL, 
    [PTABegin] DATETIME NOT NULL, 
    [PTAEnd] DATETIME NULL, 
    CONSTRAINT [FK_Child_To_Person] FOREIGN KEY ([Person]) REFERENCES [Person]([Id]), 
    PRIMARY KEY ([Person])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'PTA Candidate',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Child',
    @level2type = NULL,
    @level2name = NULL