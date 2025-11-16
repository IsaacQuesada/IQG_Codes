CREATE PROCEDURE [dbo].[ObtenerDetalleInformeRevision]
@IdDetalleInforme UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        DIR.IdDetalleInforme,
        DIR.IdInforme,
        DIR.IdAspecto,
        DIR.Cumple,
        DIR.Observacion,
        AE.Descripcion AS NombreAspecto
    FROM DetalleInformeRevision DIR
    INNER JOIN AspectoAEvaluar AE ON DIR.IdAspecto = AE.IdAspecto
    WHERE DIR.IdDetalleInforme = @IdDetalleInforme
END