using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors()]
    public class DNSGPSController : ControllerBase
    {
        private readonly ILogger<DNSGPSController> _logger;

        public DNSGPSController(ILogger<DNSGPSController> logger)
        {
            _logger = logger;
        }


        [EnableCors()]
        [HttpGet]
        public async Task<DNSGPS> ApiRequest()
        {
            string[,] matrizTiempos = new string[10, 10];
            matrizTiempos = Webscrapping.EjecutarTiempo();

            string[,] matrizCoordenadas = new string[10, 10];
            matrizCoordenadas = Webscrapping.EjecutarCoordenadas();

            using (HttpClient client = new HttpClient())
            {
            
                //HttpResponseMessage responseMessage = await client.GetAsync("https://api.tomtom.com/routing/1/calculateRoute/52.50931%2C13.42936%3A52.50274%2C13.43872/json?instructionsType=coded&avoid=unpavedRoads&key=QNDSKoghJXsfleTToOkVBTPLwkaYbauA");
                HttpResponseMessage responseMessage = await client.GetAsync("https://api.tomtom.com/routing/1/calculateRoute/52.50931%2C13.42936%3A52.50274%2C13.43872/json?maxAlternatives=2&instructionsType=coded&avoid=unpavedRoads&key=QNDSKoghJXsfleTToOkVBTPLwkaYbauA");
                HttpContent httpcontent = responseMessage.Content;
                string content = await httpcontent.ReadAsStringAsync();

                JObject jObject = JObject.Parse(content);
                JToken jRutas = jObject["routes"];


                Resumen resumen = new Resumen(jRutas.Values("summary"));

                IEnumerable<JToken> rutas = jRutas.Values("guidance").Values("instructions");
                List<Ruta> listaRutas = new List<Ruta>();

                foreach(JToken jRuta in rutas)
                {
                    listaRutas.Add(new Ruta(jRuta));
                }

                return new DNSGPS(resumen, listaRutas);
            }
        }

        [EnableCors()]
        [Route("login")]
        [HttpGet]
        public HttpResponseMessage login()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(
                    "<strong>test</strong>",
                    Encoding.UTF8,
                    "text/html"
                )
            };
        }

    }
}
