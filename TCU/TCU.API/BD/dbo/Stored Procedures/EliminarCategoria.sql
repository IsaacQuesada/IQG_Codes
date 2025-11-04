




CREATE PROCEDURE  [dbo].[EliminarCategoria]
@IdCategoria uniqueidentifier
AS
BEGIN
	
	SET NOCOUNT ON;
	BEGIN TRANSACTION
		DELETE 
		FROM Categoria 
		WHERE (IdCategoria=@IdCategoria)
		SELECT @IdCategoria
	COMMIT TRANSACTION
END