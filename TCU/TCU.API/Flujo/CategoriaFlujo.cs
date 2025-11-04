using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class CategoriaFlujo : ICategoriaFlujo
    {
        private ICategoriaDA _categoriaDA;

        public CategoriaFlujo(ICategoriaDA categoriaDA)
        {
            _categoriaDA = categoriaDA;
        }

        public async Task<Guid> Agregar(Categoria categoria)
        {
            return await _categoriaDA.Agregar(categoria);
        }

        public async Task<Guid> Editar(Guid IdCategoria, Categoria categoria)
        {
            return await _categoriaDA.Editar(IdCategoria, categoria);
        }

        public async Task<Guid> Eliminar(Guid IdCategoria)
        {
            return await _categoriaDA.Eliminar(IdCategoria);
        }

        public async Task<IEnumerable<CategoriaResponse>> Obtener()
        {
            return await _categoriaDA.Obtener();
        }

        public async Task<Categoria> Obtener(Guid IdCategoria)
        {
            return await _categoriaDA.Obtener(IdCategoria);
        }
    }
}
