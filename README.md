# Trabajo de la Universidad: Clase Vector en C#

Este proyecto representa un trabajo académico de la universidad en el que desarrollamos una clase Vector en JavaScript. Esta clase permite realizar cálculos matemáticos utilizando un array como base y está diseñada para llevar a cabo una variedad de operaciones matemáticas.

Visita la version Web [Clase-Vector](https://clase-vector-vanilla-javascript.vercel.app/)

<div align="center">
  <a href="https://clase-vector-vanilla-javascript.vercel.app/">
    <img src="https://i.ibb.co/xqYrbBH/clase-vector-csharp.png" alt="clase-vector-csharp" border="0">
  </a>
</div>


## Características

La clase Vector en JavaScript incluye las siguientes características y operaciones:

- **Creación de Vectores:** Puedes crear un nuevo objeto Vector vacío e ir cargándolo con elementos, o cargarlo con valores aleatorios en un rango específico.
  
- **Selección de Elementos:** La clase ofrece métodos para seleccionar elementos específicos basados en ciertos criterios, como primos, no primos, buenos valores, etc.

- **Operaciones Matemáticas:** Incluye operaciones matemáticas comunes como suma, resta, producto escalar, magnitud, producto cruz y más.

- **Ordenamiento:** Puedes ordenar el vector tanto de forma ascendente como descendente utilizando varios algoritmos, como el ordenamiento por intercambio y el ordenamiento burbuja.

- **Búsquedas:** Ofrece búsquedas binarias y secuenciales para encontrar elementos específicos en el vector.

- **Operaciones de Conjuntos:** Permite realizar operaciones de conjuntos como intersección, unión y diferencia entre conjuntos representados por vectores.

- **Eliminación de Duplicados:** Puedes eliminar duplicados del vector.

## Ejemplo: 

```csharp

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea

class vector
    {
        private const int max = 100;
        private int[] v;
        private int n;
        // Constructor de la clase vector
        public vector()
        {
            v = new int[max];
            n = 0;
        }

        // metodos que tienen la capacidad de acceder a variables que estan por fuera de ellos
        public void CargarRandom(int n1, int a, int b)
        {
            Random r = new Random();
            n = n1;
            for (int i = 1; i <= n; i++)
                v[i] = r.Next(a, b + 1);
        }

        // Metodo para cargar por elemento
        public void CargarElementoXElemento(int dato)
        {
            n++;
            v[n] = dato;
        }

        // etc...
    }
```

La Clase Vector se apoya de una clase NEnt (numero entero) para funcionar

## Ejemplo:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{
    class NEnt
    {
        private int valor;

        public NEnt()
        {
            valor = 0;
        }

        public void Cargar(int numero)
        {
            valor = numero;
        }

        public string Descargar()
        {
            return valor.ToString();
        }

        public void Invertir()
        {
            int digito;
            int resultado = 0;
            int numero = valor;
            while (numero > 0)
            {
                digito = numero % 10;
                resultado = resultado * 10 + digito;
                numero /= 10;
            }
            valor = resultado;
        }
        public void Ndigs()
        {
            int numeroDigs = valor.ToString().Length;
            valor = numeroDigs;
        }
        public bool VerificarPar()
        {
            return valor % 2 == 0;
        }
        public bool VerificarPrimo()
        {
            int i, c, r;
            c = 0;
            for(i=1;i<= valor; i++)
            {
                r = valor % i;
                if (r == 0)
                    c++;
            }
            return c == 2;
        }

        public bool VerificarCapicua()
        {
            int capicua = this.valor;
            this.Invertir();
            return capicua == this.valor;
        }
    }
}

```
