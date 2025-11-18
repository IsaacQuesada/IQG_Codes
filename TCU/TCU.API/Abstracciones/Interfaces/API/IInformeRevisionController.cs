using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IInformeRevisionController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid IdInforme);
        Task<IActionResult> Agregar(InformeRevisionRequest informe);
        Task<IActionResult> Editar(Guid IdInforme, InformeRevisionRequest informe);
        Task<IActionResult> Eliminar(Guid IdInforme);
    }
}
