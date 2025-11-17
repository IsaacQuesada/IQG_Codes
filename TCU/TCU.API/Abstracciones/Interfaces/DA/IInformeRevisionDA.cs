using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IInformeRevisionDA
    {
        Task<IEnumerable<InformeRevisionResponse>> Obtener();
        Task<InformeRevisionResponse> Obtener(Guid IdInforme);
        Task<Guid> Agregar(InformeRevisionRequest informe);
        Task<Guid> Editar(Guid IdInforme, InformeRevisionRequest informe);
        Task<Guid> Eliminar(Guid IdInforme);
    }
}
