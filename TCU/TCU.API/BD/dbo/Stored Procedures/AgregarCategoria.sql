


CREATE PROCEDURE  [dbo].[AgregarCategoria]
@IdCategoria uniqueidentifier,
@Nombre as varchar(max)
AS
BEGIN
	
	SET NOCOUNT ON;
    BEGIN TRANSACTION
	    INSERT INTO [dbo].[Categoria]
               ([IdCategoria]
               ,[Nombre])
         VALUES
               (@IdCategoria,@Nombre)
        SELECT @IdCategoria
    COMMIT TRANSACTION
END