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
    public static void EjecutarCoordenadas()
    {
        var html = @"http://html-agility-pack.net/";
        HtmlWeb web = new HtmlWeb();
        var htmlDoc = web.Load(html);


    }

    public static void EjecutarTiempo()
    {
        var html = @"http://www.tiempo.com/";
        HtmlWeb web = new HtmlWeb();
        web.OverrideEncoding = Encoding.UTF8;
        var htmlDoc = web.Load(html);

        public List<string> tiempos = new List<string>();
        var nodes = htmlDoc.DocumentNode.SelectNodes("//abbr[@class='des-mapa']");
        foreach (HtmlNode node in nodes)
        {
            tiempos.Add(node.InnerText);
        }

        public List<string> provincias = new List<string>();
        nodes = htmlDoc.DocumentNode.SelectNodes("//dt");
        foreach (HtmlNode node in nodes)
        {
            provincias.Add(node.InnerText);
        }

        using (TextWriter tw = new StreamWriter("provincias.txt"))
        {
            foreach (String provincia in provincias)
                tw.WriteLine(provincia);
        }

        /*public matrizTiempos = new string[10,10];

        for (int i=0; i< provincias.Count; i++){
            for (int j=0; j < 2; j++){
                if (j==0){ matrizTiempos[i][j] = provincias[i]; }
                else { matrizTiempos[i][j] = tiempos[i]; }
            }
        }*/

    }
}
