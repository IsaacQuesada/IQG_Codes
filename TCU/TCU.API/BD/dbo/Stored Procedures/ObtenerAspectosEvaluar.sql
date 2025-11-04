
/*
This query text was retrieved from showplan XML, and may be truncated.
*/

CREATE PROCEDURE  [dbo].[ObtenerAspectosEvaluar]
AS
BEGIN
	
	SET NOCOUNT ON;
SELECT AspectoAEvaluar.IdAspecto, AspectoAEvaluar.IdCategoria, AspectoAEvaluar.Descripcion, AspectoAEvaluar.Activo, Categoria.Nombre AS NombreCategoria
	FROM     AspectoAEvaluar INNER JOIN
					  Categoria ON AspectoAEvaluar.IdCategoria = Categoria.IdCategoria 
END