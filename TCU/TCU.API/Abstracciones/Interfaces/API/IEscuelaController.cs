using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.API
{
    public interface IEscuelaController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid IdEscuela);
        Task<IActionResult> Agregar(EscuelaBase escuela);
        Task<IActionResult> Editar(Guid IdEscuela, EscuelaBase escuela);
        Task<IActionResult> Eliminar(Guid IdEscuela);

    }
}
