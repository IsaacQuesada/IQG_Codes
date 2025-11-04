
/*
This query text was retrieved from showplan XML, and may be truncated.
*/

CREATE PROCEDURE  [dbo].[ObtenerEscuela]
@IdEscuela uniqueidentifier
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT Escuela.IdEscuela, Escuela.Codigo, Escuela.NombreCentroEducativo, Escuela.NombreDirector
	FROM     Escuela 
	WHERE  (Escuela.IdEscuela = @IdEscuela)
END