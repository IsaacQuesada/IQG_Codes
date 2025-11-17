using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class InformeRevisionFlujo : IInformeRevisionFlujo
    {
        private IInformeRevisionDA _informeRevisionDA;

        public InformeRevisionFlujo(IInformeRevisionDA informeRevisionDA)
        {
            _informeRevisionDA = informeRevisionDA;
        }

        public async Task<Guid> Agregar(InformeRevisionRequest informe)
        {
           return await _informeRevisionDA.Agregar(informe);
        }

        public async Task<Guid> Editar(Guid IdInforme, InformeRevisionRequest informe)
        {
            return await _informeRevisionDA.Editar(IdInforme, informe);
        }

        public async Task<Guid> Eliminar(Guid IdInforme)
        {
            return await _informeRevisionDA.Eliminar(IdInforme);
        }

        public async Task<IEnumerable<InformeRevisionResponse>> Obtener()
        {
            return await _informeRevisionDA.Obtener();
        }

        public async Task<InformeRevisionResponse> Obtener(Guid IdInforme)
        {
            return await _informeRevisionDA.Obtener(IdInforme);
        }
    }
}
