using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class InformeRevisionDA : IInformeRevisionDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public InformeRevisionDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(InformeRevisionRequest informe)
        {
            string query = @"AgregarInformeRevision";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdInforme = Guid.NewGuid(),
                Fecha = informe.Fecha,
                ObservacionGeneral = informe.ObservacionGeneral,
                IdEscuela = informe.IdEscuela
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid IdInforme, InformeRevisionRequest informe)
        {
            await verificarInformeRevisionExiste(IdInforme);
            string query = @"EditarInformeRevision";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdInforme = IdInforme,
                Fecha = informe.Fecha,
                ObservacionGeneral = informe.ObservacionGeneral,
                IdEscuela = informe.IdEscuela
            }); 
            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid IdInforme)
        {
            await verificarInformeRevisionExiste(IdInforme);
            string query = @"EliminarInformeRevision";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdInforme = IdInforme
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<InformeRevisionResponse>> Obtener()
        {
            string query = @"ObtenerInformesRevision";
            var resultadoConsulta = await _sqlConnection.QueryAsync<InformeRevisionResponse>(query);
            return resultadoConsulta;
        }

        public async Task<InformeRevisionResponse> Obtener(Guid IdInforme)
        {
            string query = @"ObtenerInformeRevision";
            var resultadoConsulta = await _sqlConnection.QueryAsync<InformeRevisionResponse>(query, new
            {
                IdInforme = IdInforme
            });
            return resultadoConsulta.FirstOrDefault();
        }
        #region Helpers
        private async Task verificarInformeRevisionExiste(Guid IdInforme)
        {
            InformeRevisionResponse? resultadoConsultaInformeRevision = await Obtener(IdInforme);
            if (resultadoConsultaInformeRevision == null)
                throw new Exception("El informe no existe");
        }
        #endregion
    }
}
