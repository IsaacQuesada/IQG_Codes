using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abstracciones.Modelos;
using System.Net.Http.Json;
using System.Text.Json;

namespace Web.Pages.Informes
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;

        [BindProperty(SupportsGet = true)]
        public Guid IdEscuela { get; set; }

        public List<InformeRevisionResponse> Informes { get; set; } = new();

        public IndexModel(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IActionResult> OnGetAsync(Guid idEscuela)
        {
            IdEscuela = idEscuela;

            // Consumimos el endpoint para obtener TODOS los informes (sin filtro)
            var url = _config["ApiEndPoints:UrlBase"] +
                      _config.GetSection("ApiEndPoints:Metodos").Get<List<MetodoConfig>>()
                             .First(m => m.Nombre == "ObtenerInformes").Valor;

            var cliente = new HttpClient();

            var response = await cliente.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Error al cargar los informes.");
                Informes = new List<InformeRevisionResponse>();
                return Page();
            }

            var json = await response.Content.ReadAsStringAsync();
            var todosInformes = JsonSerializer.Deserialize<List<InformeRevisionResponse>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Filtrar localmente los informes por IdEscuela
            Informes = todosInformes.Where(i => i.IdEscuela == IdEscuela).ToList();

            return Page();
        }

        public class MetodoConfig
        {
            public string Nombre { get; set; }
            public string Valor { get; set; }
        }
    }
}
