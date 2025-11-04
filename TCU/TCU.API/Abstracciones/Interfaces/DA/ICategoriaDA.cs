using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface ICategoriaDA
    {
        Task<IEnumerable<CategoriaResponse>> Obtener();
        Task<Categoria> Obtener(Guid IdCategoria);
        Task<Guid> Agregar(Categoria categoria);
        Task<Guid> Editar(Guid IdCategoria, Categoria categoria);
        Task<Guid> Eliminar(Guid IdCategoria);
    }
}
