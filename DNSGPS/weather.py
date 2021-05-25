from bs4 import BeautifulSoup
import requests
import pandas as pd

url = 'https://www.tiempo.com/'
pagina = requests.get(url)
soup = BeautifulSoup(pagina.content, 'html.parser')

#Tiempo
tiempos = soup.find_all('abbr', class_="des-mapa")
lista_tiempos = list()
tam_tiempos = len(tiempos)

for i in range(0,tam_tiempos,2):
    lista_tiempos.append(tiempos[i].text)

print(lista_tiempos)

#Provincias
provincias = soup.findAll('dt')
lista_ciudades = list()

for provincia in provincias:
    lista_ciudades.append(provincia.text)

print(lista_ciudades)

with open('provincias.txt','w') as temp_file:
    for item in lista_ciudades:
        item = item.rstrip()
        item = item.lstrip()
        temp_file.write("%s\n" % item)

df = pd.DataFrame({'Provincica':lista_ciudades,'Tiempo':lista_tiempos})

df.to_csv('Ciudades-Tiempos.csv', index=False)
