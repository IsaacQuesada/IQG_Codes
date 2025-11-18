using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Abstracciones.Modelos;
using Microsoft.Extensions.Configuration;

namespace Web.Pages.Aspectos
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _http;

        public IList<AspectoEvaluarResponse> Aspectos { get; set; } = new List<AspectoEvaluarResponse>();

        public IndexModel(IConfiguration config)
        {
            _config = config;
            _http = new HttpClient();
        }

        public async Task OnGetAsync()
        {
            string url = _config["ApiEndPoints:UrlBase"] + "AspectoEvaluar";

            var response = await _http.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Aspectos = JsonSerializer.Deserialize<List<AspectoEvaluarResponse>>(json, opciones);
            }
        }
    }
}
