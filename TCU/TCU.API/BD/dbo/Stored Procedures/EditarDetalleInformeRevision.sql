CREATE PROCEDURE [dbo].[EditarDetalleInformeRevision]
@IdDetalleInforme UNIQUEIDENTIFIER,
@IdInforme UNIQUEIDENTIFIER,
@IdAspecto UNIQUEIDENTIFIER,
@Cumple BIT,
@Observacion VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION
        UPDATE [dbo].[DetalleInformeRevision]
           SET [IdInforme] = @IdInforme,
               [IdAspecto] = @IdAspecto,
               [Cumple] = @Cumple,
               [Observacion] = @Observacion
         WHERE IdDetalleInforme = @IdDetalleInforme

        SELECT @IdDetalleInforme
    COMMIT TRANSACTION
END