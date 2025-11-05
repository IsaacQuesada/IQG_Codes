using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class AspectoEvaluarDA : IAspectoEvaluarDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public AspectoEvaluarDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #region Operaciones
        public async Task<Guid> Agregar(AspectoEvaluarRequest aspectoEvaluar)
        {
            string query = @"AgregarAspectoEvaluar";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdAspecto = Guid.NewGuid(),
                Descripcion = aspectoEvaluar.Descripcion,
                Activo = aspectoEvaluar.Activo,
                IdCategoria = aspectoEvaluar.IdCategoria
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid IdAspecto, AspectoEvaluarRequest aspectoEvaluar)
        {
            await verificarAspectoEvaluarExiste(IdAspecto);
            string query = @"EditarAspectoEvaluar";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdAspecto = IdAspecto,
                Descripcion = aspectoEvaluar.Descripcion,
                Activo = aspectoEvaluar.Activo,
                IdCategoria = aspectoEvaluar.IdCategoria
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid IdAspecto)
        {
            await verificarAspectoEvaluarExiste(IdAspecto);
            string query = @"EliminarAspectoEvaluar";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdAspecto = IdAspecto
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<AspectoEvaluarResponse>> Obtener()
        {
            string query = @"ObtenerAspectosEvaluar";
            var resultadoConsulta = await _sqlConnection.QueryAsync<AspectoEvaluarResponse>(query);
            return resultadoConsulta;
        }

        public async Task<AspectoEvaluarResponse> Obtener(Guid IdAspecto)
        {
            string query = @"ObtenerAspectoEvaluar";
            var resultadoConsulta = await _sqlConnection.QueryAsync<AspectoEvaluarResponse>(query, new
            {
                IdAspecto = IdAspecto
            });
            return resultadoConsulta.FirstOrDefault();
        }
        #endregion
        #region Helpers
        private async Task verificarAspectoEvaluarExiste(Guid IdAspecto)
        {
            AspectoEvaluarResponse? resultadoConsultaAspectoEvaluar = await Obtener(IdAspecto);
            if (resultadoConsultaAspectoEvaluar == null)
                throw new Exception("El aspecto a evaluar no existe");
        }
        #endregion
    }
}
