
/*
This query text was retrieved from showplan XML, and may be truncated.
*/


CREATE PROCEDURE  [dbo].[AgregarAspectoEvaluar]
@IdAspecto uniqueidentifier,
@IdCategoria as uniqueidentifier,
@Descripcion as varchar(max),
@Activo as bit
AS
BEGIN
	
	SET NOCOUNT ON;
    BEGIN TRANSACTION
	    INSERT INTO [dbo].[AspectoAEvaluar]
               ([IdAspecto]
               ,[IdCategoria]
               ,[Descripcion]
               ,[Activo])
         VALUES
               (@IdAspecto,@IdCategoria,@Descripcion,@Activo)
        SELECT @IdAspecto
    COMMIT TRANSACTION
END