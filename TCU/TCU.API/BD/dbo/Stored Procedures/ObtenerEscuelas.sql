-- =============================================
-- Author:		<Author>
-- Create date: <Create Date>
-- Description:	Obtiene todas las escuelas
-- =============================================
CREATE PROCEDURE ObtenerEscuelas
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [IdEscuela],
		   [Codigo],
		   [NombreCentroEducativo],
		   [NombreDirector]
	FROM [dbo].[Escuela]
END