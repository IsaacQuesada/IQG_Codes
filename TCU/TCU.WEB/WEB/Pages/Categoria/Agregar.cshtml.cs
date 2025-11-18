using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abstracciones.Modelos;
using System.Net.Http.Json;
using System.Text.Json;

namespace Web.Pages.Categorias
{
    public class AgregarModel : PageModel
    {
        private readonly IConfiguration _config;

        public AgregarModel(IConfiguration config)
        {
            _config = config;
        }

        [BindProperty]
        public Categoria Categoria { get; set; } = new();

        public void OnGet()
        {
            // Nada especial en Get para agregar
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            string endpoint = _config.GetSection("ApiEndPoints:Metodos")
                                   .Get<List<MetodoConfig>>()
                                   .First(x => x.Nombre == "AgregarCategoria").Valor;

            endpoint = _config["ApiEndPoints:UrlBase"] + endpoint;

            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(endpoint, Categoria);
            response.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }

    public class MetodoConfig
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }
    }
}
