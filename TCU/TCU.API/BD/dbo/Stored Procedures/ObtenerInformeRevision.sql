CREATE PROCEDURE [dbo].[ObtenerInformeRevision]
@IdInforme UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IR.IdInforme,
        IR.IdEscuela,
        IR.Fecha,
        IR.ObservacionGeneral,
        E.NombreCentroEducativo AS NombreCentroEducativo
    FROM InformeRevision IR
    INNER JOIN Escuela E ON IR.IdEscuela = E.IdEscuela
    WHERE IR.IdInforme = @IdInforme
END