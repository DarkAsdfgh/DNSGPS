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

public static class Webscrapping
{
    public static string[,] EjecutarTiempo()
    {
        var html = @"http://www.tiempo.com/";
        HtmlWeb web = new HtmlWeb();
        web.OverrideEncoding = Encoding.UTF8;
        var htmlDoc = web.Load(html);

        List<string> tiempos = new List<string>();
        var nodes = htmlDoc.DocumentNode.SelectNodes("//abbr[@class='des-mapa']");
        
        for (int i=0; i<nodes.Count; i = i + 2)
        {
            tiempos.Add(nodes[i].InnerText);
        }
        
        List<string> provincias = new List<string>();
        nodes = htmlDoc.DocumentNode.SelectNodes("//dt");
        foreach (HtmlNode node in nodes)
        {
            provincias.Add(node.InnerText);
        }

        string[,] matrizTiempos = new string[10, 10];

        for (int i=0; i< provincias.Count; i++){
            for (int j=0; j < 2; j++){
                if (j==0){ matrizTiempos[i,j] = provincias[i]; }
                else { matrizTiempos[i,j] = tiempos[i]; }
            }
        }

        return matrizTiempos;

    }

    public static string[,] EjecutarCoordenadas()
    {
        List<string> ciudades = new List<string>();

        System.IO.StreamReader file = System.IO.StreamReader(@"");
        int i = 0;
        while( ( ciudades[i] = file.ReadLine() )!= null)
        {
            i++;
        }
        List<string> listaLatitudes = new List<string>();
        List<string> listaLongitudes = new List<string>();
        for (int j=0; j<ciudades.Count; i++)
        {
            var url = @"http://www.tiempo.com/" + ciudades[j];
            HtmlWeb webCoord = new HtmlWeb();
            webCoord.OverrideEncoding = Encoding.UTF8;
            var htmlDocCoord = webCoord.Load(url);

            var latitudes = htmlDocCoord.DocumentNode.SelectNodes("//span[@class='latitude']");
            var longitudes = htmlDocCoord.DocumentNode.SelectNodes("//span[@class='longitude']");

            for (int k=0; k<1; k++)
            {
                listaLatitudes.Append(latitudes[k].InnerText);
                listaLongitudes.Append(longitudes[k].InnerText);

            }

        }

        string[,] matrizCoordenadas = new string[10, 10];
        for (int i = 0; i < ciudades.Count; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (j == 0) { matrizCoordenadas[i, j] = ciudades[i]; }
                else if(j==1) { matrizCoordenadas[i, j] = listaLatitudes[i]; }
                else { matrizCoordenadas[i, j] = listaLongitudes[i]; }
            }
        }

        return matrizCoordenadas;



    }


}
