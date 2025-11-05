using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class AspectoEvaluarFlujo : IAspectoEvaluarFlujo
    {
        private IAspectoEvaluarDA _aspectoEvaluarDA;

        public AspectoEvaluarFlujo(IAspectoEvaluarDA aspectoEvaluarDA)
        {
            _aspectoEvaluarDA = aspectoEvaluarDA;
        }

        public async Task<Guid> Agregar(AspectoEvaluarRequest aspectoEvaluar)
        {
            return await _aspectoEvaluarDA.Agregar(aspectoEvaluar);
        }

        public async Task<Guid> Editar(Guid IdAspecto, AspectoEvaluarRequest aspectoEvaluar)
        {
            return await _aspectoEvaluarDA.Editar(IdAspecto, aspectoEvaluar);
        }

        public async Task<Guid> Eliminar(Guid IdAspecto)
        {
            return await _aspectoEvaluarDA.Eliminar(IdAspecto);
        }

        public async Task<IEnumerable<AspectoEvaluarResponse>> Obtener()
        {
            return await _aspectoEvaluarDA.Obtener();
        }

        public Task<AspectoEvaluarResponse> Obtener(Guid IdAspecto)
        {
            return _aspectoEvaluarDA.Obtener(IdAspecto);
        }
    }
}
