CREATE TABLE [dbo].[DetalleInformeRevision] (
    [IdDetalleInforme] UNIQUEIDENTIFIER NOT NULL,
    [IdInforme]        UNIQUEIDENTIFIER NOT NULL,
    [IdAspecto]        UNIQUEIDENTIFIER NOT NULL,
    [Cumple]           BIT              NOT NULL,
    [Observacion]      VARCHAR (MAX)    NULL,
    PRIMARY KEY CLUSTERED ([IdDetalleInforme] ASC),
    CONSTRAINT [FK_DetalleInforme_Aspecto] FOREIGN KEY ([IdAspecto]) REFERENCES [dbo].[AspectoAEvaluar] ([IdAspecto]),
    CONSTRAINT [FK_DetalleInforme_Informe] FOREIGN KEY ([IdInforme]) REFERENCES [dbo].[InformeRevision] ([IdInforme]) ON DELETE CASCADE
);

