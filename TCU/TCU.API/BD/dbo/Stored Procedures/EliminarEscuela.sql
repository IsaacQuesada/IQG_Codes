



CREATE PROCEDURE  [dbo].[EliminarEscuela]
@IdEscuela uniqueidentifier
AS
BEGIN
	
	SET NOCOUNT ON;
	BEGIN TRANSACTION
		DELETE 
		FROM Escuela 
		WHERE (IdEscuela=@IdEscuela)
		SELECT @IdEscuela
	COMMIT TRANSACTION
END