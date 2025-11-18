using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IDetalleInformeRevisionFlujo
    {
        Task<IEnumerable<DetalleInformeRevisionResponse>> Obtener();
        Task<DetalleInformeRevisionResponse> Obtener(Guid IdDetalleInforme);
        Task<Guid> Agregar(DetalleInformeRevisionRequest detalle);
        Task<Guid> Editar(Guid IdDetalleInforme, DetalleInformeRevisionRequest detalle);
        Task<Guid> Eliminar(Guid IdDetalleInforme);
    }
}