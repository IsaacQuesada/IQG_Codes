using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IAspectoEvaluarController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid IdAspectoEvaluar);
        Task<IActionResult> Agregar(AspectoEvaluarRequest aspectoEvaluar);
        Task<IActionResult> Editar(Guid IdAspectoEvaluar, AspectoEvaluarRequest aspectoEvaluar);
        Task<IActionResult> Eliminar(Guid IdAspectoEvaluar);
    }
}
