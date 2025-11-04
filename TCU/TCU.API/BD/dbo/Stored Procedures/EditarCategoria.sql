




CREATE PROCEDURE  [dbo].[EditarCategoria]
@IdCategoria as uniqueidentifier,
@Nombre as varchar(max)


AS
BEGIN
	
	SET NOCOUNT ON;
    BEGIN TRANSACTION
        UPDATE [dbo].[Categoria]
           SET [Nombre] = @Nombre
         WHERE IdCategoria=@IdCategoria
         SELECT @IdCategoria
    COMMIT TRANSACTION
END