
/*
This query text was retrieved from showplan XML, and may be truncated.
*/


CREATE PROCEDURE  [dbo].[EditarAspectoEvaluar]
@IdAspecto as uniqueidentifier,
@IdCategoria as uniqueidentifier,
@Descripcion as varchar(max),
@Activo as varchar(max)
AS
BEGIN
	
	SET NOCOUNT ON;
    BEGIN TRANSACTION
        UPDATE [dbo].[AspectoAEvaluar]
           SET [IdCategoria] = @IdCategoria
              ,[Descripcion] = @Descripcion
              ,[Activo] = @Activo
         WHERE IdAspecto=@IdAspecto
         SELECT @IdAspecto
    COMMIT TRANSACTION
END