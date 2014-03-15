CREATE TABLE [dbo].[FamilyParticipants]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Family] INT NOT NULL, 
    [Person] INT NOT NULL, 
    [Relation] INT NULL, 
    [PTABegin] DATETIME NOT NULL, 
    [PTAEnd] DATETIME NULL, 
    CONSTRAINT [FK_FamilyParticipants_To_Family] FOREIGN KEY ([Family]) REFERENCES [Family]([Id]), 
    CONSTRAINT [FK_FamilyParticipants_To_Person] FOREIGN KEY ([Person]) REFERENCES [Person]([Id]), 
    CONSTRAINT [FK_FamilyParticipants_To_Relation] FOREIGN KEY ([Relation]) REFERENCES [Relation]([Id]),
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'PTA Candidate',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'FamilyParticipants',
    @level2type = NULL,
    @level2name = NULL