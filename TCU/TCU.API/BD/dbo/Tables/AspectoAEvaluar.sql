CREATE TABLE [dbo].[AspectoAEvaluar] (
    [IdAspecto]   UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [IdCategoria] UNIQUEIDENTIFIER NOT NULL,
    [Descripcion] VARCHAR (MAX)    NULL,
    [Activo]      BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdAspecto] ASC),
    CONSTRAINT [FK_AspectoAEvaluar_Categoria] FOREIGN KEY ([IdCategoria]) REFERENCES [dbo].[Categoria] ([IdCategoria])
);

