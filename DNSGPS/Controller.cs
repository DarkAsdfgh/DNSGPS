using javax.jws;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DNSGPS
{
    public static class Controller
    {
        [WebMethod]
        public static async Task<Ruta> ApiRequest(string origen, string destino)
        {
            string[,] matrizTiempos = new string[10, 10];
            matrizTiempos = Webscrapping.EjecutarTiempo();

            string[,] matrizCoordenadas = new string[10, 10];
            matrizCoordenadas = Webscrapping.EjecutarCoordenadas();

            string coordenadas = Coordenadas.CambiaACoordenadas(origen, destino, matrizCoordenadas);
            string ciudad = Coordenadas.CambiaACiudad(coordenadas, matrizCoordenadas);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync("https://api.tomtom.com/routing/1/calculateRoute/" + coordenadas + "/json?maxAlternatives=2&instructionsType=coded&avoid=unpavedRoads&key=QNDSKoghJXsfleTToOkVBTPLwkaYbauA");
                HttpContent httpcontent = responseMessage.Content;
                string content = await httpcontent.ReadAsStringAsync();

                JObject jObject = JObject.Parse(content);
                JToken jRutas = jObject["routes"];

                Resumen resumen = new Resumen(jRutas.Values("summary"));

                IEnumerable<JToken> rutas = jRutas.Values("guidance").Values("instructions");
                List<DatosRuta> listaRutas = new List<DatosRuta>();

                foreach(JToken jRuta in rutas)
                {
                    listaRutas.Add(new DatosRuta(jRuta));
                }

                List<string> coords = listaRutas[0].coordenadas;
                List<string> ciudades = new List<string>();
                string tiempo_origen = Coordenadas.TiempoCiudad(origen, matrizTiempos);
                string tiempo_destino = Coordenadas.TiempoCiudad(destino, matrizTiempos);

                for(int i = 0; i < coords.Count; i++)
                {
                    ciudades.Add(Coordenadas.CambiaACiudad(coords[i], matrizCoordenadas));
                }

                return new Ruta(resumen, listaRutas, ciudades, tiempo_origen, tiempo_destino);
            }
        }

        public static HttpResponseMessage login()
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
