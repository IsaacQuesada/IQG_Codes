
-- =============================================
-- Author:		<Author>
-- Create date: <Create Date>
-- Description:	Obtiene todas las escuelas
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerCategorias]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [IdCategoria],
		   [Nombre]
	FROM [dbo].[Categoria]
END