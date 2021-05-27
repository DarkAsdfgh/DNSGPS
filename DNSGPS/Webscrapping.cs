using System.Collections.Generic;
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

        string[,] matrizTiempos = new string[52, 2];

        for (int i=0; i< 52; i++){   
            for (int j=0; j < 2; j++){
                if (j==0){ matrizTiempos[i,j] = provincias[i]; }
                else { matrizTiempos[i,j] = tiempos[i]; }
            }
        }

        return matrizTiempos;

    }

    public static string[,] EjecutarCoordenadas()
    {
        List<string> ciudades = new List<string>()
        {
            "Almería",
            "Vitoria - Gasteiz",
            "Albacete",
            "Madrid",
            "Alicante",
            "Ávila",
            "Badajoz",
            "Palma de Mallorca",
            "Barcelona",
            "Burgos",
            "Ciudad Real",
            "Cáceres",
            "Cadiz",
            "Granada",
            "Córdoba_(España)",
            "A Coruña",
            "Girona",
            "Castellón de la Plana",
            "Guadalajara_(España)",
            "Cuenca_(España)",
            "Huelva",
            "Jaén",
            "León_(España)",
            "Lleida",
            "Huesca",
            "Donostia - San Sebastián",
            "Logroño",
            "Lugo",
            "Málaga",
            "Murcia",
            "Ourense",
            "Palencia",
            "Las Palmas de Gran Canaria",
            "Pontevedra",
            "Pamplona",
            "Oviedo",
            "Sevilla",
            "Salamanca",
            "Segovia",
            "Santa Cruz de Tenerife",
            "Santander_(España)",
            "Soria",
            "Tarragona",
            "Teruel",
            "Toledo",
            "Zamora",
            "Bilbao",
            "Valencia",
            "Valladolid",
            "Zaragoza",
            "Ceuta",
            "Melilla"
        };
        //string path = Directory.GetCurrentDirectory() + @"\provincias.txt";
       // System.IO.StreamReader file = new System.IO.StreamReader(path);
        string ciudad ="";
        /*while ((ciudad = file.ReadLine())!= null)
        {
            ciudades.Add(ciudad);
        }*/
        List<string> listaLatitudes = new List<string>();
        List<string> listaLongitudes = new List<string>();

        HtmlWeb webCoord = new HtmlWeb();
        webCoord.OverrideEncoding = Encoding.UTF8;

        for (int j = 0; j < 52; j++)
        {
            
            var url = @"http://es.wikipedia.org/wiki/" + ciudades[j];
            var htmlDocCoord = webCoord.Load(url);
            htmlDocCoord.OptionEmptyCollection = true;
            var latitudes = htmlDocCoord.DocumentNode.SelectNodes("//span[@class='geo']//span[@class='latitude']");
            var longitudes = htmlDocCoord.DocumentNode.SelectNodes("//span[@class='geo']//span[@class='longitude']");

            for (int k=0; k<1; k++)
            {
                listaLatitudes.Add(latitudes[k].InnerText.Trim());
                listaLongitudes.Add(longitudes[k].InnerText.Trim());   
            }
            
        }

        string[,] matrizCoordenadas = new string[52, 2];
        for (int i = 0; i < 52; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j == 0) { matrizCoordenadas[i, j] = ciudades[i]; }
                else if(j==1) { matrizCoordenadas[i, j] = listaLatitudes[i] + listaLongitudes[i]; } //latitud,longitud
            }
        }

        return matrizCoordenadas;



    }


}
