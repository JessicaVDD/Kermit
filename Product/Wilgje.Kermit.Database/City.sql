CREATE TABLE [dbo].[City]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ZipCode] VARCHAR(100) NULL, 
    [Name] VARCHAR(1000) NOT NULL, 
    [Country] INT NOT NULL, 
    CONSTRAINT [FK_City_To_Country] FOREIGN KEY (Country) REFERENCES [Country]([Id])
)
