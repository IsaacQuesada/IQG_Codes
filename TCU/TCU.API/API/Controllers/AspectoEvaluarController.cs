using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspectoEvaluarController : ControllerBase, IAspectoEvaluarController
    {
        private IAspectoEvaluarFlujo _aspectoEvaluarFlujo;
        private ILogger<AspectoEvaluarController> _logger;

        public AspectoEvaluarController(IAspectoEvaluarFlujo aspectoEvaluarFlujo, ILogger<AspectoEvaluarController> logger)
        {
            _aspectoEvaluarFlujo = aspectoEvaluarFlujo;
            _logger = logger;
        }
        #region Operaciones
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] AspectoEvaluarRequest aspectoEvaluar)
        {
            var resultado = await _aspectoEvaluarFlujo.Agregar(aspectoEvaluar);
            return CreatedAtAction(nameof(Obtener), new { IdAspecto = resultado }, null);
        }
        [HttpPut("{IdAspecto}")]
        public async Task<IActionResult> Editar([FromRoute] Guid IdAspecto, [FromBody] AspectoEvaluarRequest aspectoEvaluar)
        {
            if (!await VerificarAspectoEvaluarExiste(IdAspecto))
                return NotFound("El aspecto a evaluar no existe");
            var resultado = await _aspectoEvaluarFlujo.Editar(IdAspecto, aspectoEvaluar);
            return Ok(resultado);
        }
        [HttpDelete("{IdAspecto}")]
        public async Task<IActionResult> Eliminar([FromRoute]Guid IdAspecto)
        {
            if (!await VerificarAspectoEvaluarExiste(IdAspecto))
                return NotFound("El aspecto a evaluar no existe");
            var resultado = await _aspectoEvaluarFlujo.Eliminar(IdAspecto);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _aspectoEvaluarFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }
        [HttpGet("{IdAspecto}")]
        public async Task<IActionResult> Obtener([FromRoute]Guid IdAspecto)
        {
            var resultado = await _aspectoEvaluarFlujo.Obtener(IdAspecto);
            return Ok(resultado);
        }
        #endregion
        #region Helpers
        private async Task<bool> VerificarAspectoEvaluarExiste(Guid IdAspecto)
        {
            var resultadoValidacion = false;
            var resultadoAspectoEvaluarExiste = await _aspectoEvaluarFlujo.Obtener(IdAspecto);
            if (resultadoAspectoEvaluarExiste != null)
                resultadoValidacion = true;
            return resultadoValidacion;
        }
        #endregion
    }
}
