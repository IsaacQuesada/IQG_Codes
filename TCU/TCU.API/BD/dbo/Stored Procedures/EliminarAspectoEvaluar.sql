
/*
This query text was retrieved from showplan XML, and may be truncated.
*/


CREATE PROCEDURE  [dbo].[EliminarAspectoEvaluar]
@IdAspecto uniqueidentifier
AS
BEGIN
	
	SET NOCOUNT ON;
	BEGIN TRANSACTION
		DELETE 
		FROM AspectoAEvaluar 
		WHERE (IdAspecto=@IdAspecto)
		SELECT @IdAspecto
	COMMIT TRANSACTION
END