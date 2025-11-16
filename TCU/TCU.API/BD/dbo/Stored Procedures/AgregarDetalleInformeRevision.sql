CREATE PROCEDURE [dbo].[AgregarDetalleInformeRevision]
@IdDetalleInforme UNIQUEIDENTIFIER,
@IdInforme UNIQUEIDENTIFIER,
@IdAspecto UNIQUEIDENTIFIER,
@Cumple BIT,
@Observacion VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION
        INSERT INTO [dbo].[DetalleInformeRevision]
               ([IdDetalleInforme], [IdInforme], [IdAspecto], [Cumple], [Observacion])
        VALUES (@IdDetalleInforme, @IdInforme, @IdAspecto, @Cumple, @Observacion)

        SELECT @IdDetalleInforme
    COMMIT TRANSACTION
END