using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface ICategoriaController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid IdCategoria);
        Task<IActionResult> Agregar(Categoria categoria);
        Task<IActionResult> Editar(Guid IdCategoria, Categoria categoria);
        Task<IActionResult> Eliminar(Guid IdCategoria);
    }
}
