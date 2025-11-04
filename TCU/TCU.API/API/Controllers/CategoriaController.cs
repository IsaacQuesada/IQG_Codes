using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase, ICategoriaController
    {
        private ICategoriaFlujo _categoriaFlujo;
        private ILogger<CategoriaController> _logger;

        public CategoriaController(ICategoriaFlujo categoriaFlujo, ILogger<CategoriaController> logger)
        {
            _categoriaFlujo = categoriaFlujo;
            _logger = logger;
        }
        #region Operaciones
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] Categoria categoria)
        {
            var resultado = await _categoriaFlujo.Agregar(categoria);
            return CreatedAtAction(nameof(Obtener), new { IdCategoria = resultado }, null);
        }
        [HttpPut("{IdCategoria}")]
        public async Task<IActionResult> Editar([FromRoute] Guid IdCategoria, [FromBody] Categoria categoria)
        {
            if (!await VerificarCategoriaExiste(IdCategoria))
                return NotFound("La categoria no existe");
            var resultado = await _categoriaFlujo.Editar(IdCategoria, categoria);
            return Ok(resultado);
        }
        [HttpDelete("{IdCategoria}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid IdCategoria)
        {
            if (!await VerificarCategoriaExiste(IdCategoria))
                return NotFound("La categoria no existe");
            var resultado = await _categoriaFlujo.Eliminar(IdCategoria);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _categoriaFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }
        [HttpGet("{IdCategoria}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid IdCategoria)
        {
            var resultado = await _categoriaFlujo.Obtener(IdCategoria);
            return Ok(resultado);
        }

        #endregion
        #region Helpers
        private async Task<bool> VerificarCategoriaExiste(Guid IdCategoria)
        {
            var resultadoValidacion = false;
            var resultadoCategoriaExiste = await _categoriaFlujo.Obtener(IdCategoria);
            if (resultadoCategoriaExiste != null)
                resultadoValidacion = true;
            return resultadoValidacion;
        }
        #endregion
    }
}
