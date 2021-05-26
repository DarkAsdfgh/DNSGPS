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


namespace DNSGPS
{
    public class Coordenadas
    {
        public static string CambiaACoordenadas(string origen, string destino, string[,] matrizCoordenadas)
        {
            var coordenadas = "";
            for (int i=0; i<52; i++)
            {
                if (matrizCoordenadas[i,0].Contains(origen))
                {
                    coordenadas = matrizCoordenadas[i, 1] + ":" + matrizCoordenadas[i,2];
                }                
            }
            return coordenadas;
        }
    }
}
