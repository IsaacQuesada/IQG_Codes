using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.Pages.Escuelas
{
    public class EditarModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _http;

        public EditarModel(IConfiguration config)
        {
            _config = config;
            _http = new HttpClient();
        }

        [BindProperty]
        public EscuelaResponse Escuela { get; set; }

        // Clase auxiliar para mapear configuración
        public class MetodoConfig
        {
            public string Nombre { get; set; }
            public string Valor { get; set; }
        }

        private string GetEndpoint(string nombre, params object[] args)
        {
            var metodos = _config.GetSection("ApiEndPoints:Metodos").Get<List<MetodoConfig>>();
            var metodo = metodos.FirstOrDefault(x => x.Nombre == nombre);

            if (metodo == null)
                throw new Exception($"No se encontró el método {nombre} en la configuración.");

            return _config["ApiEndPoints:UrlBase"] + string.Format(metodo.Valor, args);
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return RedirectToPage("./Index");

            string url = GetEndpoint("ObtenerEscuela", id.Value);

            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "No se pudo obtener la escuela.";
                return RedirectToPage("./Index");
            }

            var json = await response.Content.ReadAsStringAsync();

            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            Escuela = JsonSerializer.Deserialize<EscuelaResponse>(json, opciones);

            if (Escuela == null)
            {
                TempData["Error"] = "Escuela no encontrada.";
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            string url = GetEndpoint("EditarEscuela", Escuela.IdEscuela);

            var response = await _http.PutAsJsonAsync(url, Escuela);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Error al actualizar la escuela.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
