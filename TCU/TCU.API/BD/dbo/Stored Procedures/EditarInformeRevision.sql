CREATE PROCEDURE [dbo].[EditarInformeRevision]
@IdInforme UNIQUEIDENTIFIER,
@IdEscuela UNIQUEIDENTIFIER,
@Fecha DATETIME,
@ObservacionGeneral VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION
        UPDATE [dbo].[InformeRevision]
           SET [IdEscuela] = @IdEscuela,
               [Fecha] = @Fecha,
               [ObservacionGeneral] = @ObservacionGeneral
         WHERE IdInforme = @IdInforme

        SELECT @IdInforme
    COMMIT TRANSACTION
END