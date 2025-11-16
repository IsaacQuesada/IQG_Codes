CREATE PROCEDURE [dbo].[EliminarDetalleInformeRevision]
@IdDetalleInforme UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION
        DELETE FROM [dbo].[DetalleInformeRevision]
        WHERE IdDetalleInforme = @IdDetalleInforme

        SELECT @IdDetalleInforme
    COMMIT TRANSACTION
END