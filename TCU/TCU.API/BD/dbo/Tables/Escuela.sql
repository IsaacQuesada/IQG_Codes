CREATE TABLE [dbo].[Escuela] (
    [IdEscuela]             UNIQUEIDENTIFIER NOT NULL,
    [Codigo]                INT              NOT NULL,
    [NombreCentroEducativo] VARCHAR (200)    NOT NULL,
    [NombreDirector]        VARCHAR (200)    NOT NULL,
    CONSTRAINT [PK_Escuela] PRIMARY KEY CLUSTERED ([IdEscuela] ASC)
);

