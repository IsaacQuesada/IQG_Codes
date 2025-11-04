using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class EscuelaDA : IEscuelaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public EscuelaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        #region Operaciones
        public async Task<Guid> Agregar(EscuelaBase escuela)
        {
            string query = @"AgregarEscuela";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdEscuela = Guid.NewGuid(),
                Codigo = escuela.Codigo,
                NombreCentroEducativo = escuela.NombreCentroEducativo,
                NombreDirector = escuela.NombreDirector
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid IdEscuela, EscuelaBase escuela)
        {
            await verificarEscuelaExiste(IdEscuela);
            string query = @"EditarEscuela";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdEscuela = IdEscuela,
                Codigo = escuela.Codigo,
                NombreCentroEducativo = escuela.NombreCentroEducativo,
                NombreDirector = escuela.NombreDirector
            });
            return resultadoConsulta;

        }

        public async Task<Guid> Eliminar(Guid IdEscuela)
        {
            await verificarEscuelaExiste(IdEscuela);
            string query = @"EliminarEscuela";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdEscuela = IdEscuela
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<EscuelaResponse>> Obtener()
        {
            string query = @"ObtenerEscuelas";
            var resultadoConsulta = await _sqlConnection.QueryAsync<EscuelaResponse>(query);
            return resultadoConsulta;
        }

        public async Task<EscuelaResponse> Obtener(Guid IdEscuela)
        {
            string query = @"ObtenerEscuela";
            var resultadoConsulta = await _sqlConnection.QueryAsync<EscuelaResponse>(query, new
            {
                IdEscuela = IdEscuela
            });
            return resultadoConsulta.FirstOrDefault();
        }

        #endregion

        #region Helpers
        private async Task verificarEscuelaExiste(Guid IdEscuela)
        {
            EscuelaResponse? resultadoConsultaEscuela = await Obtener(IdEscuela);
            if (resultadoConsultaEscuela == null)
            {
                throw new Exception("La escuela no existe");
            }
        }
        #endregion
    }
}
