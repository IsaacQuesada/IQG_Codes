CREATE PROCEDURE [dbo].[EliminarInformeRevision]
@IdInforme UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION
        DELETE FROM [dbo].[InformeRevision]
        WHERE IdInforme = @IdInforme

        SELECT @IdInforme
    COMMIT TRANSACTION
END