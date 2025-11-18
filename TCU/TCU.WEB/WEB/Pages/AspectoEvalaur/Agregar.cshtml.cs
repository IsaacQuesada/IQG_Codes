using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abstracciones.Modelos;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.Pages.Aspectos
{
    public class AgregarModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _http;

        public AgregarModel(IConfiguration config)
        {
            _config = config;
            _http = new HttpClient();
        }

        [BindProperty]
        public AspectoEvaluarRequest Aspecto { get; set; } = new();

        public List<SelectListItem> ListaCategorias { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            await CargarCategoriasAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await CargarCategoriasAsync();

            if (!ModelState.IsValid)
                return Page();

            string url = _config["ApiEndPoints:UrlBase"] + "AspectoEvaluar";

            var response = await _http.PostAsJsonAsync(url, Aspecto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al guardar el aspecto: {errorContent}");
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private async Task CargarCategoriasAsync()
        {
            string urlCategorias = _config["ApiEndPoints:UrlBase"] + "Categoria";

            var response = await _http.GetAsync(urlCategorias);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                var categorias = JsonSerializer.Deserialize<List<CategoriaResponse>>(json, opciones);
                if (categorias != null)
                {
                    ListaCategorias = categorias
                        .Select(c => new SelectListItem
                        {
                            Value = c.IdCategoria.ToString(),
                            Text = c.Nombre
                        }).ToList();
                }
            }
            else
            {
                ListaCategorias = new List<SelectListItem>(); // o manejar error
            }
        }
    }
}
