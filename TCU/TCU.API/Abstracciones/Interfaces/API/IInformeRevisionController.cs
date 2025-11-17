using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
