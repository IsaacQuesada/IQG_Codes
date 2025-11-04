

/*
This query text was retrieved from showplan XML, and may be truncated.
*/

CREATE PROCEDURE  [dbo].[ObtenerCategoria]
@IdCategoria uniqueidentifier
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT Categoria.IdCategoria, Categoria.Nombre
	FROM     Categoria 
	WHERE  (Categoria.IdCategoria = @IdCategoria)
END