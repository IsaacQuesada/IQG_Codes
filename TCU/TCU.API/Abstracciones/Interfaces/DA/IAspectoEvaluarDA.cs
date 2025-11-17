using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IAspectoEvaluarDA
    {
        Task<IEnumerable<AspectoEvaluarResponse>> Obtener();
        Task<AspectoEvaluarResponse> Obtener(Guid IdAspecto);
        Task<Guid> Agregar(AspectoEvaluarRequest aspectoEvaluar);
        Task<Guid> Editar(Guid IdAspecto, AspectoEvaluarRequest aspectoEvaluar);
        Task<Guid> Eliminar(Guid IdAspecto);
    }
}
