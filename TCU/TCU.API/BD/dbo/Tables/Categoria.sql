CREATE TABLE [dbo].[Categoria] (
    [IdCategoria] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Nombre]      VARCHAR (100)    NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCategoria] ASC)
);

