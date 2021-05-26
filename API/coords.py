#!/usr/bin/env python
# -*- coding: utf-8 -*-
from BeautifulSoup import BeautifulSoup
import requests
import pandas as pd

file = open('provincias.txt', 'r')
provincias = file.read()

lista_provincias = list()
nombre = ""
for i in provincias:
    if i != "\n":
        nombre = nombre + i
    else:
        lista_provincias.append(nombre)
        nombre=""
print(lista_provincias)

if lista_provincias.__contains__("Cuenca"):
    lista_provincias.remove("Cuenca")
    lista_provincias.append("Cuenca_(España)")
if lista_provincias.__contains__("Cordoba"):
        lista_provincias.remove("Cordoba")
        lista_provincias.append("Córdoba_(España)")
if lista_provincias.__contains__("Guadalajara"):
        lista_provincias.remove("Guadalajara")
        lista_provincias.append("Guadalajara_(España)")
if lista_provincias.__contains__("León"):
        lista_provincias.remove("León")
        lista_provincias.append("León_(España)")
if lista_provincias.__contains__("Santander"):
        lista_provincias.remove("Santander")
        lista_provincias.append("Santander_(España)")
print(lista_provincias)


lista_latitudes = list()
lista_longitudes = list()

for provincia in lista_provincias:
    url = 'https://es.wikipedia.org/wiki/' + provincia
    pagina = requests.get(url)
    soup = BeautifulSoup(pagina.content, 'html.parser')

    # Coordenadas
    latitudes = soup.find_all('span', class_="latitude")
    longitudes = soup.find_all('span', class_="longitude")
    for i in range(0,1):
        lista_latitudes.append(latitudes[i].text)
        lista_longitudes.append(longitudes[i].text)
        print(provincia,'lat =',latitudes[i].text,'long=',longitudes[i].text)

df = pd.DataFrame({'Provincica':lista_provincias,'Latitud':lista_latitudes, 'Longitud': lista_longitudes})

df.to_csv('Ciudades-Latitud-Longitud.csv', index=False)
