



CREATE PROCEDURE  [dbo].[EditarEscuela]
@IdEscuela as uniqueidentifier,
@Codigo as int,
@NombreCentroEducativo as varchar(max),
@NombreDirector as varchar(max)


AS
BEGIN
	
	SET NOCOUNT ON;
    BEGIN TRANSACTION
        UPDATE [dbo].[Escuela]
           SET [Codigo] = @Codigo
              ,[NombreCentroEducativo] = @NombreCentroEducativo
              ,[NombreDirector] = @NombreDirector
         WHERE IdEscuela=@IdEscuela
         SELECT @IdEscuela
    COMMIT TRANSACTION
END