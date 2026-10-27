"""
carrera(lista)
Escriba una función recursiva de cola carrera(lista) que reciba una lista no nula que contiene las velocidades
promedio para una carrera de n caballos y obtenga:
a) Cuántos caballos lograron velocidad de más de 30 kms.
b) Cuántos caballos lograron velocidad de menos o igual a 30 kms.
c) Cuál es la velocidad mayor y cuál la menor.
d) El promedio de todas las velocidades.
La lista solo se puede recorrer una vez. No puede utilizar las funciones predefinidas de Python min y max.
carrera([35, 25, 30, 35])
(2, 2, 35, 25, 31.25)
"""
def carrera(lista:list) -> list:
    masDeThirty = 0
    menosDeThirty = 0
    mayor = lista[0]
    menor = lista[0]
    suma = 0
    for elemento in lista:
        if elemento > mayor:
            mayor = elemento
        if elemento < menor:
            menor = elemento
        if elemento > 30:
            masDeThirty += 1
        else:
            menosDeThirty += 1
        suma += elemento
    return [masDeThirty, menosDeThirty, mayor, menor, suma / len(lista)]

"""
split(ele, lista)
Construya una función recursiva de cola de nombre split(ele, lista). Esta función toma una lista que contiene
dígitos (no debe verificarlo) y la parte en números enteros usando como punto de corte a "ele".
 split('x', [1, 4, 7, 'x', 1, 2, 3])
[147, 123]
 split('x', [1, 2, 3,'x',4, 5, 6, 7,'x',8, 9])
[123, 4567, 89]]
 split('x', [1, 4, 7, 1, 2, 3])
[147123]
"""
def split(ele, lista:list, resultado:list) -> list:
    ...
"""
simetrica(lista1, lista2)
Escriba una función iterativa simetrica, que reciba como argumentos dos listas y obtenga una lista compuesta
por los números de la primera lista que no pertenecen a la segunda lista y por los dígitos de la segunda lista que
no pertenecen a la primera.
Ejemplos:
 simetrica([1,2,3,4], [2,5,4])
[1, 3, 5]
 simetrica([1,4,6,8], [8,6,6,1,2,4])
[2]
 simetrica([1,2,3], [4,5,6])
[1, 2, 3, 4, 5, 6]
 simetrica([1,2,3], [3,2,1])
[ ] # lista nula
"""
if __name__ == "__main__":
    print(carrera([35, 25, 30, 35]))
