using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformeRevisionController : ControllerBase, IInformeRevisionController
    {
        private IInformeRevisionFlujo _informeRevisionFlujo;
        private ILogger<InformeRevisionController> _logger;

        public InformeRevisionController(IInformeRevisionFlujo informeRevisionFlujo, ILogger<InformeRevisionController> logger)
        {
            _informeRevisionFlujo = informeRevisionFlujo;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] InformeRevisionRequest informe)
        {
            var resultado = await _informeRevisionFlujo.Agregar(informe);
            return CreatedAtAction(nameof(Obtener), new { IdInforme = resultado }, null);
        }
        [HttpPut("{IdInforme}")]
        public async Task<IActionResult> Editar([FromRoute] Guid IdInforme, [FromBody] InformeRevisionRequest informe)
        {
            if (!await VerificarInformeRevisionExiste(IdInforme))
                return NotFound("El informe de revision no existe");
            var resultado = await _informeRevisionFlujo.Editar(IdInforme, informe);
            return Ok(resultado);
        }
        [HttpDelete("{IdInforme}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid IdInforme)
        {
            if (!await VerificarInformeRevisionExiste(IdInforme))
                return NotFound("El informe de revision no existe");
            var resultado = await _informeRevisionFlujo.Eliminar(IdInforme);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _informeRevisionFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }
        [HttpGet("{IdInforme}")]
        public async Task<IActionResult> Obtener([FromRoute]Guid IdInforme)
        {
            var resultado = await _informeRevisionFlujo.Obtener(IdInforme);
            return Ok(resultado);
        }

        #region Helpers
        private async Task<bool> VerificarInformeRevisionExiste(Guid IdInforme)
        {
            var resultadoValidacion = false;
            var resultadoInformeRevisionExiste = await _informeRevisionFlujo.Obtener(IdInforme);
            if (resultadoInformeRevisionExiste != null)
                resultadoValidacion = true;
            return resultadoValidacion;
        }
        #endregion
    }
}
