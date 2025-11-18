using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.Pages.Informes
{
    public class AgregarModel : PageModel
    {
        private readonly IConfiguration _config;

        public AgregarModel(IConfiguration config)
        {
            _config = config;
        }

        [BindProperty]
        public InformeRevisionRequest Informe { get; set; } = new();

        [BindProperty]
        public List<DetalleInformeRevisionRequest> Detalles { get; set; } = new();

        public List<AspectoEvaluarResponse> Aspectos { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public Guid IdEscuela { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (IdEscuela == Guid.Empty)
                return BadRequest("IdEscuela es requerido");

            Informe.IdEscuela = IdEscuela;
            await CargarAspectos();
            return Page();
        }

        private async Task CargarAspectos()
        {
            try
            {
                var httpClient = new HttpClient();
                var url = $"{_config["ApiEndPoints:UrlBase"]}AspectoEvaluar";

                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Aspectos = JsonSerializer.Deserialize<List<AspectoEvaluarResponse>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                else
                {
                    Aspectos = new List<AspectoEvaluarResponse>();
                }
            }
            catch
            {
                Aspectos = new List<AspectoEvaluarResponse>();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await CargarAspectos();
                return Page();
            }

            var httpClient = new HttpClient();
            var urlInforme = $"{_config["ApiEndPoints:UrlBase"]}InformeRevision";

            var responseInforme = await httpClient.PostAsJsonAsync(urlInforme, Informe);

            if (!responseInforme.IsSuccessStatusCode)
            {
                var errorContent = await responseInforme.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al crear el informe: {responseInforme.StatusCode} - {errorContent}");
                await CargarAspectos();
                return Page();
            }

            var idInformeCreado = await responseInforme.Content.ReadFromJsonAsync<Guid>();

            if (Detalles != null && Detalles.Count > 0)
            {
                var urlDetalle = $"{_config["ApiEndPoints:UrlBase"]}DetalleInformeRevision";

                foreach (var detalle in Detalles)
                {
                    detalle.IdInforme = idInformeCreado;
                    var responseDetalle = await httpClient.PostAsJsonAsync(urlDetalle, detalle);
                    if (!responseDetalle.IsSuccessStatusCode)
                    {
                        var errorDetalle = await responseDetalle.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, $"Error al agregar detalle: {responseDetalle.StatusCode} - {errorDetalle}");
                        await CargarAspectos();
                        return Page();
                    }
                }
            }

            return RedirectToPage("./Index", new { idEscuela = Informe.IdEscuela });
        }
    }
}
