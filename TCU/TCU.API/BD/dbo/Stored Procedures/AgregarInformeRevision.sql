CREATE PROCEDURE [dbo].[AgregarInformeRevision]
@IdInforme UNIQUEIDENTIFIER,
@IdEscuela UNIQUEIDENTIFIER,
@Fecha DATETIME,
@ObservacionGeneral VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION
        INSERT INTO [dbo].[InformeRevision]
               ([IdInforme], [IdEscuela], [Fecha], [ObservacionGeneral])
        VALUES (@IdInforme, @IdEscuela, @Fecha, @ObservacionGeneral)

        SELECT @IdInforme
    COMMIT TRANSACTION
END