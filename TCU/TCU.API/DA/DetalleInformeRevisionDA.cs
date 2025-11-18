using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class DetalleInformeRevisionDA : IDetalleInformeRevisionDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public DetalleInformeRevisionDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(DetalleInformeRevisionRequest detalle)
        {
            string query = @"AgregarDetalleInformeRevision";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdDetalleInforme = Guid.NewGuid(),
                IdInforme = detalle.IdInforme,
                IdAspecto = detalle.IdAspecto,
                Cumple = detalle.Cumple,
                Observacion = detalle.Observacion
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid IdDetalleInforme, DetalleInformeRevisionRequest detalle)
        {
            await verificarDetalleInformeRevisionExiste(IdDetalleInforme);
            string query = @"EditarDetalleInformeRevision";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdDetalleInforme = IdDetalleInforme,
                IdInforme = detalle.IdInforme,
                IdAspecto = detalle.IdAspecto,
                Cumple = detalle.Cumple,
                Observacion = detalle.Observacion
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid IdDetalleInforme)
        {
            await verificarDetalleInformeRevisionExiste(IdDetalleInforme);
            string query = @"EliminarDetalleInformeRevision";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdDetalleInforme = IdDetalleInforme
            });
            return resultadoConsulta; 

        }

        public async Task<IEnumerable<DetalleInformeRevisionResponse>> Obtener()
        {
            string query = @"ObtenerDetallesInformeRevision";
            var resultadoConsulta = await _sqlConnection.QueryAsync<DetalleInformeRevisionResponse>(query);
            return resultadoConsulta;
        }

        public async Task<DetalleInformeRevisionResponse> Obtener(Guid IdDetalleInforme)
        {
            string query = @"ObtenerDetalleInformeRevision";
            var resultadoConsulta = await _sqlConnection.QueryAsync<DetalleInformeRevisionResponse>(query, new
            {
                IdDetalleInforme = IdDetalleInforme
            });
            return resultadoConsulta.FirstOrDefault();
        }

        #region Helpers
        private async Task verificarDetalleInformeRevisionExiste(Guid IdDetalleInforme)
        {
            DetalleInformeRevisionResponse? resultadoConsultaDetalleInformeRevision = await Obtener(IdDetalleInforme);
            if (resultadoConsultaDetalleInformeRevision == null)
                throw new Exception("El detalle del informe no existe");
        }
        #endregion

    }
}
