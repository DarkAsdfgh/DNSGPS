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

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors()]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [EnableCors()]
        [HttpGet]
        public async void ApiRequest()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync("https://api.tomtom.com/routing/1/calculateRoute/52.50931%2C13.42936%3A52.50274%2C13.43872/json?avoid=unpavedRoads&key=QNDSKoghJXsfleTToOkVBTPLwkaYbauA");
                HttpContent httpcontent = responseMessage.Content;
                string content = await httpcontent.ReadAsStringAsync();
                Console.WriteLine(content);
                JObject jObject = JObject.Parse(content);

                foreach (JProperty property in jObject.Properties())
                {
                    {
                        Console.WriteLine(property.Name + " - " + property.Value);
                    }
                }
            }
        }

        [EnableCors()]
        [Route("prueba")]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
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
