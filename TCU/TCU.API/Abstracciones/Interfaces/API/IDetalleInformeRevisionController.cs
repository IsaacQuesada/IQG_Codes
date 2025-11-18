using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IDetalleInformeRevisionController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid IdDetalleInforme);
        Task<IActionResult> Agregar(DetalleInformeRevisionRequest detalle);
        Task<IActionResult> Editar(Guid IdDetalleInforme, DetalleInformeRevisionRequest detalle);
        Task<IActionResult> Eliminar(Guid IdDetalleInforme);
    }
}
