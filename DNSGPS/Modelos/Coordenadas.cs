namespace DNSGPS
{
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
                return "Coordenadas indeterminadas";
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
                    return ciudad;
                }
            }
            
            return coordCambiar;

        }
        public static string TiempoCiudad(string nombreCiudad, string[,] matrizTiempos)
        {
            string tiempo = "";
            for (int i=0; i < 52; i++)
            {
                if (matrizTiempos[i,0].Contains(nombreCiudad))
                {
                    tiempo = matrizTiempos[i,1];
                    return tiempo;
                }
            }
            tiempo = "Tiempo indeterminado";
            return tiempo;

        }
    }
}        
