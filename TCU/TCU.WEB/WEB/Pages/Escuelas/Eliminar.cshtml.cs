using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.Pages.Escuelas
{
    public class EliminarModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _http;

        public EliminarModel(IConfiguration config)
        {
            _config = config;
            _http = new HttpClient();
        }

        [BindProperty]
        public EscuelaResponse Escuela { get; set; }

        private string GetEndpoint(string nombre, params object[] args)
        {
            var metodos = _config.GetSection("ApiEndPoints:Metodos").Get<MetodoConfig[]>();
            var metodo = Array.Find(metodos, m => m.Nombre == nombre);

            if (metodo == null)
                throw new Exception($"No se encontró el método {nombre} en configuración.");

            return _config["ApiEndPoints:UrlBase"] + string.Format(metodo.Valor, args);
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || id == Guid.Empty)
                return NotFound();

            var url = GetEndpoint("ObtenerEscuela", id.Value);

            var response = await _http.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "No se pudo obtener la escuela para eliminar.";
                return RedirectToPage("./Index");
            }

            var json = await response.Content.ReadAsStringAsync();

            Escuela = JsonSerializer.Deserialize<EscuelaResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (Escuela == null)
            {
                TempData["Error"] = "Escuela no encontrada.";
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Escuela == null || Escuela.IdEscuela == Guid.Empty)
                return NotFound();

            var url = GetEndpoint("EliminarEscuela", Escuela.IdEscuela);

            var response = await _http.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar la escuela.");
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private class MetodoConfig
        {
            public string Nombre { get; set; }
            public string Valor { get; set; }
        }
    }
}
