using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class CategoriaDA : ICategoriaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public CategoriaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        #region Operaciones
        public async Task<Guid> Agregar(Categoria categoria)
        {
            string query = @"AgregarCategoria";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdCategoria = Guid.NewGuid(),
                Nombre = categoria.Nombre
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid IdCategoria, Categoria categoria)
        {
            await verificarCategoriaExiste(IdCategoria);
            string query = @"EditarCategoria";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdCategoria = IdCategoria,
                Nombre = categoria.Nombre
            });
            return resultadoConsulta;

        }

        public async Task<Guid> Eliminar(Guid IdCategoria)
        {
            await verificarCategoriaExiste(IdCategoria);
            string query = @"EliminarCategoria";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdCategoria = IdCategoria
            });
            return resultadoConsulta;
        }

        public Task<IEnumerable<CategoriaResponse>> Obtener()
        {
            string query = @"ObtenerCategorias";
            var resultadoConsulta = _sqlConnection.QueryAsync<CategoriaResponse>(query);
            return resultadoConsulta;
        }

        public async Task<Categoria> Obtener(Guid IdCategoria)
        {
            string query = @"ObtenerCategoria";
            var resultadoConsulta = await _sqlConnection.QueryAsync<Categoria>(query, new
            {
                IdCategoria = IdCategoria
            });
            return resultadoConsulta.FirstOrDefault();

        }
        #endregion
        #region Helpers
        private async Task verificarCategoriaExiste(Guid IdCategoria)
        {
            Categoria? resultadoConsultaCategoria = await Obtener(IdCategoria);
            if (resultadoConsultaCategoria == null)
            {
                throw new Exception("La categoría no existe");
            }
        }
        #endregion
    }
}
