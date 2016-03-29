Buscaminas
==========

## Objetivo

## Resultado buscado
El juego del Buscaminas consiste en descubrir las minas ocultas en un tablero de MxN casillas a partir de las indicaciones que nos da el propio juego acerca del número de minas que se ocultan en las casillas adyacentes, ya sea horizontalmente, verticalmente o diagonálmente  a una casilla dada.
El ejercicio de programación aquí propuesto parte de esa misma estructura –el campo de minas representado por una matriz MxN– para ofrecer como resultado un nuevo tablero con las minas descubiertas y el número de minas adyacentes para cada casilla que no tenga mina.
Considérese el siguiente tablero de ejemplo, donde las minas se representan por un asterisco y las casillas vacías por un punto:

    +-+-+-+-+
    |*|.|.|.|          Dimensiones: 4x4
    +-+-+-+-+          Minas: (1,1) y (3,2)
    |.|.|.|.|
    +-+-+-+-+
    |.|*|.|.|
    +-+-+-+-+
    |.|.|.|.|
    +-+-+-+-+

Para este caso concreto, la solución que debería entregar el programa sería la siguiente:

    *100
    2210
    1*10
    1110


Se pide escribir un programa capaz de calcular este tipo de soluciones para cualquier tablero de dimensiones arbitrarias. A continuación se describen el formato de entrada de los datos y el formato de salida que deberá respetar el programa.

Finalmente se dan algunas indicaciones para su implementación:

* El formato de entrada de los datos tiene siempre la siguiente estructura: un par de números enteros –separados por espacios– que indican el número de filas y el número de columnas (respectivamente) del tablero, seguidos por tantas líneas como filas haya.
* Cada línea contiene asteriscos o puntos, tantos como columnas, para codificar si en una casilla hay una mina (asterisco) o no (punto).

A modo de ejemplo, el tablero mostrado anteriormente se codificaría así:

    4 4
    *...
    ....
    .*..
    ....
