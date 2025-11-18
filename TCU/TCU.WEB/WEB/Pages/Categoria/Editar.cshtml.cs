using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abstracciones.Modelos;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Web.Pages.Categorias
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
        public CategoriaResponse Categoria { get; set; }

        // Clase para mapear configuración de endpoints
        public class MetodoConfig
        {
            public string Nombre { get; set; }
            public string Valor { get; set; }
        }

        // Obtiene la URL para llamar la API según nombre y parámetros
        private string GetEndpoint(string nombre, params object[] args)
        {
            var metodos = _config.GetSection("ApiEndPoints:Metodos").Get<List<MetodoConfig>>();
            var metodo = metodos.FirstOrDefault(x => x.Nombre == nombre);

            if (metodo == null)
                throw new Exception($"No se encontró el método {nombre} en la configuración.");

            return _config["ApiEndPoints:UrlBase"] + string.Format(metodo.Valor, args);
        }

        // Carga la categoría para editar, con el Id en la URL
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return RedirectToPage("./Index");

            string url = GetEndpoint("ObtenerCategoria", id.Value);

            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "No se pudo obtener la categoría.";
                return RedirectToPage("./Index");
            }

            var json = await response.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Categoria = JsonSerializer.Deserialize<CategoriaResponse>(json, opciones);

            if (Categoria == null)
            {
                TempData["Error"] = "Categoría no encontrada.";
                return RedirectToPage("./Index");
            }

            return Page();
        }

        // Guarda cambios en la categoría
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Categoria.IdCategoria == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "El Id de la categoría es inválido.");
                return Page();
            }

            string url = GetEndpoint("EditarCategoria", Categoria.IdCategoria);

            var response = await _http.PutAsJsonAsync(url, Categoria);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al actualizar la categoría. Detalle: {errorContent}");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
