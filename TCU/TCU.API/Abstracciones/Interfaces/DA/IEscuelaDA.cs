using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IEscuelaDA
    {
        Task<IEnumerable<EscuelaResponse>> Obtener();
        Task<EscuelaResponse> Obtener(Guid IdEscuela);
        Task<Guid> Agregar(EscuelaBase escuela);
        Task<Guid> Editar(Guid IdEscuela, EscuelaBase escuela);
        Task<Guid> Eliminar(Guid IdEscuela);
    }
}
