using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using Nest;

namespace API
{
    public struct Ruta
    {
        public IEnumerable<int> tiempo;
        public IEnumerable<GeoCoordinate> coordenadas;
        public IEnumerable<string> pasos;
        public IEnumerable<string> direcciones;
        public Ruta(IEnumerable<JToken> json)
        {
            IEnumerable<int> intAux = json.Values<int>("travelTimeInSeconds");
            tiempo = intAux;

            IEnumerable<double> auxLatitudes = json.Values("point").Values<double>("latitude");
            IEnumerable<double> auxLongitudes = json.Values("point").Values<double>("longitude");

            List<GeoCoordinate> auxList = new List<GeoCoordinate>();

            for (int i = 0; i < auxLatitudes.Count(); i++)
            {
                auxList.Add(new GeoCoordinate(auxLatitudes.ElementAt(i), auxLongitudes.ElementAt(i)));
            }

            coordenadas = auxList;

            IEnumerable<String> stringAux = json.Values<string>("maneuver");
            pasos = stringAux;

            stringAux = json.Values<string>("street");
            direcciones = stringAux;
        }
    }

    public struct Resumen
    {
        public int metros;
        public int viajeEstimadoSegundos;
        public int retrasoPorTraficoSegundos;
        public int longitudTraficoMetros;
        public DateTime salida;
        public DateTime llegada;

        public Resumen(int m, int vES, int rPTS, int lTM, DateTime s, DateTime l) 
        {
            metros = m;
            viajeEstimadoSegundos = vES;
            retrasoPorTraficoSegundos = rPTS;
            longitudTraficoMetros = lTM;
            salida = s;
            llegada = l;
        }

        public Resumen(IEnumerable<JToken> json)
        {
            IEnumerable<int> intAux = json.Values<int>("lengthInMeters");
            metros = intAux.ElementAt(0);

            intAux = json.Values<int>("travelTimeInSeconds");
            viajeEstimadoSegundos = intAux.ElementAt(0);

            intAux = json.Values<int>("trafficDelayInSeconds");
            retrasoPorTraficoSegundos = intAux.ElementAt(0);

            intAux = json.Values<int>("trafficLengthInMeters");
            longitudTraficoMetros = intAux.ElementAt(0);

            IEnumerable<DateTime> dateTimeAux = json.Values<DateTime>("departureTime");
            salida = dateTimeAux.ElementAt(0);

            dateTimeAux = json.Values<DateTime>("arrivalTime");
            llegada = dateTimeAux.ElementAt(0);
        }
    }

    public class DNSGPS
    {
        public Resumen resumenViaje { get; set; }
        public IEnumerable<Ruta> listaRutas { get; set; }
        public DNSGPS(Resumen resumen, IEnumerable<Ruta> rutas)
        {
            resumenViaje = resumen;
            listaRutas = rutas;
        }
    }
}
