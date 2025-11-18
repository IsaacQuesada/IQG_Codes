using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleInformeRevisionController : ControllerBase, IDetalleInformeRevisionController
    {
        private IDetalleInformeRevisionFlujo _detalleInformeRevisionFlujo;
        private ILogger<DetalleInformeRevisionController> _logger;

        public DetalleInformeRevisionController(IDetalleInformeRevisionFlujo detalleInformeRevisionFlujo, ILogger<DetalleInformeRevisionController> logger)
        {
            _detalleInformeRevisionFlujo = detalleInformeRevisionFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] DetalleInformeRevisionRequest detalle)
        {
            var resultado = await _detalleInformeRevisionFlujo.Agregar(detalle);
            return CreatedAtAction(nameof(Obtener), new { IdDetalleInforme = resultado}, null);
        }

        [HttpPut("{IdDetalleInforme}")]
        public async Task<IActionResult> Editar([FromRoute] Guid IdDetalleInforme, [FromBody] DetalleInformeRevisionRequest detalle)
        {
            if(!await VerificarDetalleInformeRevisionExiste(IdDetalleInforme))
                return NotFound("El detalle de revisión no existe");
            var resultado = await _detalleInformeRevisionFlujo.Editar(IdDetalleInforme, detalle);
            return Ok(resultado);

        }

        [HttpDelete("{IdDetalleInforme}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid IdDetalleInforme) 
        {
            if (!await VerificarDetalleInformeRevisionExiste(IdDetalleInforme))
                return NotFound("El detalle de revisión no existe");
            var resultado = await _detalleInformeRevisionFlujo.Eliminar(IdDetalleInforme);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _detalleInformeRevisionFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("{IdDetalleInforme}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid IdDetalleInforme)
        {
            var resultado = await _detalleInformeRevisionFlujo.Obtener(IdDetalleInforme);
            return Ok(resultado);
        }

        #region Helpers
        private async Task<bool> VerificarDetalleInformeRevisionExiste(Guid IdDetalleInforme)
        {
            var resultadoValidacion = false;
            var resultadoDetalleInformeRevisionExiste = await _detalleInformeRevisionFlujo.Obtener(IdDetalleInforme);
            if (resultadoDetalleInformeRevisionExiste != null)
                resultadoValidacion = true;
            return resultadoValidacion;
        }
        #endregion
    }
}
