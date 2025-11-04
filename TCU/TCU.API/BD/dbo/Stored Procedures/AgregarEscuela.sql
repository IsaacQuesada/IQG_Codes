

CREATE PROCEDURE  [dbo].[AgregarEscuela]
@IdEscuela uniqueidentifier,
@Codigo as int,
@NombreCentroEducativo as varchar(max),
@NombreDirector as varchar(max)
AS
BEGIN
	
	SET NOCOUNT ON;
    BEGIN TRANSACTION
	    INSERT INTO [dbo].[Escuela]
               ([IdEscuela]
               ,[Codigo]
               ,[NombreCentroEducativo]
               ,[NombreDirector])
         VALUES
               (@IdEscuela,@Codigo,@NombreCentroEducativo,@NombreDirector)
        SELECT @IdEscuela
    COMMIT TRANSACTION
END