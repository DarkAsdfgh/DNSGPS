using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
using System.Collections.Specialized;
using System.IO;
using HtmlAgilityPack;
using System.Text;


public static class Coordenadas
{
    public static string CambiaACoordenadas(string origen, string destino, string[,] matrizCoordenadas)
    {
        var coordenadas_origen = "";
        var coordenadas_destino = "";
        var coordenadas = "";
        for (int i = 0; i < 52; i++)
        {
            if (matrizCoordenadas[i, 0].Contains(origen))
            {
                coordenadas_origen = matrizCoordenadas[i, 1];
            }
            else if (matrizCoordenadas[i, 0].Contains(destino))
            {
                coordenadas_destino = matrizCoordenadas[i, 1];
            }
        }
        coordenadas = coordenadas_origen + ":" + coordenadas_destino;
        if (coordenadas.Equals(""))
        {
            return "error";
        }
        else
        {
            return coordenadas;
        }
    }
    public static string CambiaACiudad(string coordCambiar, string[,] matrizCoordenadas) //37.88336,-4.7665
    {
        string ciudad = "";
        for (int i = 0; i < 52; i++)
        {
            if (matrizCoordenadas[i, 1] == coordCambiar)
            {
                ciudad = matrizCoordenadas[i, 0];
            }
        }
        if (ciudad.Equals(""))
        {
            return "error";
        }
        else
        {
            return ciudad;
        }
    }
}
            
            /* List<string> listaCoordenadas = new List<string>();
            string ciudad = "";

            ArraySegment<string> arrayCoordenadas = new ArraySegment<string>();
            arrayCoordenadas = coordCambiar.Split(",");
            double coord_lat = System.Convert.ToDouble(arrayCoordenadas[0]);
            double coord_lon = System.Convert.ToDouble(arrayCoordenadas[1]);

            Console.WriteLine(coord_lat + "   " + coord_lon);

            coord_lat = (double)(Math.Round((double)coord_lat,2));
            coord_lon = (double)(Math.Round((double)coord_lat, 2));

            for (int i = 0; i < 52; i++)
            {
                ArraySegment<string> arrayCoordMatriz = new ArraySegment<string>();
                arrayCoordMatriz = matrizCoordenadas[i,1].Split(",");
                Console.WriteLine(arrayCoordMatriz[0] + "-+-+-+-+-+" + arrayCoordMatriz[1]);
                double matCoordLat = System.Convert.ToDouble(arrayCoordMatriz[0]);
                double matCoordLon = System.Convert.ToDouble(arrayCoordMatriz[1]);
                
                matCoordLat = (double)(Math.Round((double)matCoordLat, 2));
                matCoordLon = (double)(Math.Round((double)matCoordLon, 2));

            if (coord_lat == matCoordLat && coord_lon == matCoordLon)
                {
                    ciudad = matrizCoordenadas[i, 0];
                }
            }
            if (ciudad.Equals(""))
            {
                return "error";
            }
            else
            {
                return ciudad;
            }*/
