CREATE TABLE [dbo].[Street]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(500) NOT NULL, 
    [City] INT NOT NULL, 
    CONSTRAINT [FK_Street_To_City] FOREIGN KEY ([City]) REFERENCES [City]([Id])
)
