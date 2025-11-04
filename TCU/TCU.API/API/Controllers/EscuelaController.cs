using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EscuelaController : ControllerBase, IEscuelaController
    {
        private IEscuelaFlujo _escuelaFlujo;
        private ILogger<EscuelaController> _logger;

        public EscuelaController(IEscuelaFlujo escuelaFlujo, ILogger<EscuelaController> logger)
        {
            _escuelaFlujo = escuelaFlujo;
            _logger = logger;
        }
        #region Operaciones
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] EscuelaBase escuela)
        {
            var resultado = await _escuelaFlujo.Agregar(escuela);
            return CreatedAtAction(nameof(Obtener), new { IdEscuela = resultado }, null);
        }
        [HttpPut("{IdEscuela}")]
        public async Task<IActionResult> Editar([FromRoute] Guid IdEscuela, [FromBody] EscuelaBase escuela)
        {
            if (!await VerificarEscuelaExiste(IdEscuela))
                return NotFound("La escuela no existe");
            var resultado = await _escuelaFlujo.Editar(IdEscuela, escuela);
            return Ok(resultado);
        }
        [HttpDelete("{IdEscuela}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid IdEscuela)
        {
            if (!await VerificarEscuelaExiste(IdEscuela))
                return NotFound("La escuela no existe");
            var resultado = await _escuelaFlujo.Eliminar(IdEscuela);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _escuelaFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }
        [HttpGet("{IdEscuela}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid IdEscuela)
        {
            var resultado = await _escuelaFlujo.Obtener(IdEscuela);
            return Ok(resultado);
        }

        #endregion
        #region Helpers
        private async Task<bool> VerificarEscuelaExiste(Guid IdEscuela)
        {
            var resultadoValidacion = false;
            var resultadoEscuelaExiste = await _escuelaFlujo.Obtener(IdEscuela);
            if (resultadoEscuelaExiste != null)
                resultadoValidacion = true;
            return resultadoValidacion;
        }
        #endregion
    }
}
