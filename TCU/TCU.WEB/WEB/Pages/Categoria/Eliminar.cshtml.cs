using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abstracciones.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.Pages.Categorias
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
        public CategoriaResponse Categoria { get; set; }

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

            var url = GetEndpoint("ObtenerCategoria", id.Value);

            var response = await _http.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "No se pudo obtener la categoría para eliminar.";
                return RedirectToPage("./Index");
            }

            var json = await response.Content.ReadAsStringAsync();

            Categoria = JsonSerializer.Deserialize<CategoriaResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (Categoria == null)
            {
                TempData["Error"] = "Categoría no encontrada.";
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Categoria == null || Categoria.IdCategoria == Guid.Empty)
                return NotFound();

            var url = GetEndpoint("EliminarCategoria", Categoria.IdCategoria);

            var response = await _http.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar la categoría.");
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
