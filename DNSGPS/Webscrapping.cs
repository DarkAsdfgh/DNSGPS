using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;
using System.Text;
using System;

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
        List<string> ciudades = new List<string>();
        ciudades.Add("Almería");
        ciudades.Add("Vitoria-Gasteiz");
        ciudades.Add("Albacete");
        ciudades.Add("Madrid");
        ciudades.Add("Alicante");
        ciudades.Add("Ávila");
        ciudades.Add("Badajoz");
        ciudades.Add("Palma de Mallorca");
        ciudades.Add("Barcelona");
        ciudades.Add("Burgos");
        ciudades.Add("Ciudad Real");
        ciudades.Add("Cáceres");
        ciudades.Add("Cadiz");
        ciudades.Add("Granada");
        ciudades.Add("Córdoba_(España)");
        ciudades.Add("A Coruña");
        ciudades.Add("Girona");
        ciudades.Add("Castellón de la Plana");
        ciudades.Add("Guadalajara_(España)");
        ciudades.Add("Cuenca_(España)");
        ciudades.Add("Huelva");
        ciudades.Add("Jaén");
        ciudades.Add("León_(España)");
        ciudades.Add("Lleida");
        ciudades.Add("Huesca");
        ciudades.Add("Donostia-San Sebastián");
        ciudades.Add("Logroño");
        ciudades.Add("Lugo");
        ciudades.Add("Málaga");
        ciudades.Add("Murcia");
        ciudades.Add("Ourense");
        ciudades.Add("Palencia");
        ciudades.Add("Las Palmas de Gran Canaria");
        ciudades.Add("Pontevedra");
        ciudades.Add("Pamplona");
        ciudades.Add("Oviedo");
        ciudades.Add("Sevilla");
        ciudades.Add("Salamanca");
        ciudades.Add("Segovia");
        ciudades.Add("Santa Cruz de Tenerife");
        ciudades.Add("Santander_(España)");
        ciudades.Add("Soria");
        ciudades.Add("Tarragona");
        ciudades.Add("Teruel");
        ciudades.Add("Toledo");
        ciudades.Add("Zamora");
        ciudades.Add("Bilbao");
        ciudades.Add("Valencia");
        ciudades.Add("Valladolid");
        ciudades.Add("Zaragoza");
        ciudades.Add("Ceuta");
        ciudades.Add("Melilla");

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
