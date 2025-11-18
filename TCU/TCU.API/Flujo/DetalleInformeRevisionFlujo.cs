using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class DetalleInformeRevisionFlujo : IDetalleInformeRevisionFlujo
    {
        private IDetalleInformeRevisionDA _detalleInformeRevisionDA;

        public DetalleInformeRevisionFlujo(IDetalleInformeRevisionDA detalleInformeRevisionDA)
        {
            _detalleInformeRevisionDA = detalleInformeRevisionDA;
        }

        public async Task<Guid> Agregar(DetalleInformeRevisionRequest detalle)
        {
            return await _detalleInformeRevisionDA.Agregar(detalle);
        }

        public async Task<Guid> Editar(Guid IdDetalleInforme, DetalleInformeRevisionRequest detalle)
        {
            return await _detalleInformeRevisionDA.Editar(IdDetalleInforme, detalle);
        }

        public async Task<Guid> Eliminar(Guid IdDetalleInforme)
        {
            return await _detalleInformeRevisionDA.Eliminar(IdDetalleInforme);
        }

        public async Task<IEnumerable<DetalleInformeRevisionResponse>> Obtener()
        {
            return await _detalleInformeRevisionDA.Obtener();
        }

        public async Task<DetalleInformeRevisionResponse> Obtener(Guid IdDetalleInforme)
        {
            return await _detalleInformeRevisionDA.Obtener(IdDetalleInforme);
        }
    }
}
