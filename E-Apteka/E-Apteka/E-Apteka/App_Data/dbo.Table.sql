CREATE TABLE [dbo].[tbl_data]
(
	[Id] INT IDENTITY(1,1) NOT NULL, 
    [Name] VARCHAR(MAX) NULL, 
    [Producer] VARCHAR(MAX) NULL, 
    [Price] FLOAT NULL,
	CONSTRAINT [Pk_tbl_data] PRIMARY KEY CLUSTERED([Id] ASC)
)
