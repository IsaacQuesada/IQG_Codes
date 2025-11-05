using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IAspectoEvaluarController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid IdAspecto);
        Task<IActionResult> Agregar(AspectoEvaluarRequest aspectoEvaluar);
        Task<IActionResult> Editar(Guid IdAspecto, AspectoEvaluarRequest aspectoEvaluar);
        Task<IActionResult> Eliminar(Guid IdAspecto);
    }
}
