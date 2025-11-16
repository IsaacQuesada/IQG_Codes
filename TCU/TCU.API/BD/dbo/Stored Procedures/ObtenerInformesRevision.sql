CREATE PROCEDURE [dbo].[ObtenerInformesRevision]
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
END