CREATE TABLE [dbo].[InformeRevision] (
    [IdInforme]          UNIQUEIDENTIFIER NOT NULL,
    [IdEscuela]          UNIQUEIDENTIFIER NOT NULL,
    [Fecha]              DATETIME         NOT NULL,
    [ObservacionGeneral] VARCHAR (MAX)    NULL,
    PRIMARY KEY CLUSTERED ([IdInforme] ASC),
    CONSTRAINT [FK_InformeRevision_Escuela] FOREIGN KEY ([IdEscuela]) REFERENCES [dbo].[Escuela] ([IdEscuela])
);

