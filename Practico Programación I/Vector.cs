using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Programación_I
{
    class Vector
    {
        private const int max = 100;
        private int[] v;
        private int n;
        public Vector()
        {
            v = new int[max];
            n = 0;
        }

        public void CargarRandom(int n1, int a, int b)
        {
            Random r;
            r = new Random();
            n = n1;
            int i;
            for (i = 1; i <= n; i++)
                v[i] = r.Next(a, b + 1);
        }

        public void CargarElementoXElemento(int dato)
        {
            n++;
            v[n] = dato;
        }


        public string Descargar()
        {
            string s = "";
            for (int i = 1; i <= n; i++)
                s = s + v[i] + " | ";
            return s;
        }

        //********* Metodo Auxiliares *********
        public int RetornarDimension()
        {
            return n;
        }
        public int RetornarElemento(int elemento)
        {
            return v[elemento];
        }
        public int[] RetornarVector()
        {
            return v;
        }
        //*************** Fin ******************

        // Carga n1 terminos de la sucesion de fibonacci en el vector
        public void Fibonacci(int n1)
        {
            n = n1;
            v[1] = 0;
            v[2] = 1;
            if (n < 1)
                return;
            if (n == 1)
                return;
            if (n == 2)
                return;
            for (int i = 3; i <= n; i++)
                v[i] = v[i - 1] + v[i - 2];
        }

        // Cuenta la cantidad de submultiplos en un vector
        public int ContarSubmultiplos()
        {
            int contador = 0;

            for (int i = 1; i <= n; i++)
                // Verificar si la posición es un submúltiplo del elemento resto == 0?
                if (v[i] % i == 0)
                    contador++;
            return contador;
        }

        // Busca el elemento mayor de un vector buscando por el indice "No lo entiendo mucho"
        public int BuscarElementoMayor(int indice)
        {
            int mayor;
            mayor = 0;
            for (int i = 1; i <= n; i++)
                if (i % indice == 0 && mayor < v[i])
                    mayor = v[i];

            return mayor;
        }

        // Busca la media del vector
        public double BuscarMedia(int indice)
        {
            int suma = 0;
            int contador = 0;
            for (int i = 1; i <= n; i++)
                if (i % indice == 0)
                {
                    suma = suma + v[i];
                    contador++;
                }

            return (double)suma / contador;
        }

        // Busca los elementos que son primos y los carga en otro vector
        public void BuscarPrimos(ref Vector V)
        {
            NEnt numero;
            numero = new NEnt();

            for (int i = 1; i <= n; i++)
                if (numero.VerificarPrimo(v[i]))
                    V.CargarElementoXElemento(v[i]);

        }
        
        // Busca los elementos que no son primos y los carga en otro vector
        public void BuscarNoPrimos(ref Vector V)
        {
            NEnt numero;
            numero = new NEnt();

            for (int i = 1; i <= n; i++)
                if (!numero.VerificarPrimo(v[i]))
                    V.CargarElementoXElemento(v[i]);

        }
        
        // Invierte los elementos del vector
        public void Invertir()
        {
            int inicio = 1;
            int fin = n;
            while (inicio < fin)
            {
                int temp = v[inicio];
                v[inicio] = v[fin];
                v[fin] = temp;

                inicio++;
                fin--;
            }
        }

        // Verifica si dos elementos son iguales
        public bool VerificarElementosIguales()
        {
            bool booleano = true;
            int inicial = v[1];
            for (int i = 1; i <= n; i++)
                if (inicial != v[i])
                    return false;
            return booleano;
        }

        // Este metodo elimina los elementos duplicados de un vector
        // Pero tiene un problema y es que mi vector empieza en la posicion 1
        // y la posición 0 tiene un 0 por lo que siempre elimina los ceros del vector
        // Porque ya se repite el cero en mi vector siempre
        public void EliminarDuplicados()
        {
            v = v.Distinct().ToArray();
            n = v.Length - 1;
        }

        // Intersección de Conjuntos
        public void InterseccionDeConjuntos(Vector v1, Vector v2)
        {
            int longitudV1 = v1.RetornarDimension();
            int longitudV2 = v2.RetornarDimension();
            int[] vector1 = v1.RetornarVector();
            int[] vector2 = v2.RetornarVector();

            for (int i = 1; i <= longitudV1; i++)
                for (int j = 1; j <= longitudV2; j++)
                    if (vector1[i] == vector2[j])
                    {
                        this.CargarElementoXElemento(vector1[i]);
                        break;
                    }
            this.EliminarDuplicados();
        }

        // Union de conjuntos
        public void UnionDeConjuntos(Vector v1, Vector v2)
        {
            int longitudV1 = v1.RetornarDimension();
            int longitudV2 = v2.RetornarDimension();
            int[] vector1 = v1.RetornarVector();
            int[] vector2 = v2.RetornarVector();

            for (int i = 1; i <= longitudV1; i++)
                this.CargarElementoXElemento(vector1[i]);

            for (int j = 1; j <= longitudV2; j++)
                this.CargarElementoXElemento(vector2[j]);

            this.EliminarDuplicados();
        }

        public bool VerificarOrdenSegmento(int a, int b)
        {
            // Verificar si el segmento desde a hasta b está ordenado de manera ascendente
            for (int i = a; i < b; i++)
            {
                if (v[i] > v[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        // Inserta un vector dentro de otro indicando la posición
        public void InsertarVectorPorPosicion(Vector v1, Vector v2, int posicion)
        {
            int n1 = v1.RetornarDimension();
            int n2 = v2.RetornarDimension();

            int[] vector1 = v1.RetornarVector();
            int[] vector2 = v2.RetornarVector();

            for (int i = 1; i < posicion; i++)
            {
                this.CargarElementoXElemento(vector1[i]);
            }

            for (int i = 1; i <= n2; i++)
            {
                this.CargarElementoXElemento(vector2[i]);
            }

            for (int i = posicion; i <= n1; i++)
            {
                this.CargarElementoXElemento(vector1[i]);
            }
        }

        // Elimina los elementos del vector indicando dos posiciones (rango)
        public void EliminarElementosDelVectorIndicandoLasPosiciones(int a, int b)
        {
            Vector Copia = new Vector();

            for (int i = 1; i <= n; i++)
            {
                if (i >= a && i <= b)
                    continue;
                Copia.CargarElementoXElemento(v[i]);
            }

            this.v = Copia.v;
            this.n = Copia.n;
        }

        // Duplicar elementos del vector
        public void DuplicarElementos()
        {
            Vector Copia = new Vector();

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= 2; j++)
                    Copia.CargarElementoXElemento(v[i]);

            this.v = Copia.v;
            this.n = Copia.n;
        }

        // Intercambia Elementos 
        public void IntercambiarElementos(int a, int b)
        {
            int variableAuxiliar = v[a];
            v[a] = v[b];
            v[b] = variableAuxiliar;
        }

        // Ordenamiento Burbuja Ascendente
        public void OrdenamientoBurbujaAscendente()
        {
            bool intercambio;
            do
            {
                intercambio = false;

                for (int i = 1; i < n; i++)
                    if (v[i] > v[i + 1])
                    {
                        this.IntercambiarElementos(i, i + 1);
                        intercambio = true;
                    }
            } while (intercambio);
        }

        // Ordenamiento Burbuja Descendente
        public void OrdenamientoBurbujaDescendente()
        {
            bool intercambio;
            do
            {
                intercambio = false;

                for (int i = 1; i < n; i++)
                    if (v[i] < v[i + 1])
                    {
                        int temp = v[i];
                        v[i] = v[i + 1];
                        v[i + 1] = temp;

                        intercambio = true;
                    }
            } while (intercambio);
        }

        // Ordena los elementos de un segmento
        public void OrdenarElementosDeUnSegmento(int a, int b)
        {
            Vector Vector1 = new Vector();
            Vector Vector2 = new Vector();
            Vector Vector3 = new Vector();

            for (int i = 1; i <= a - 1; i++)
                Vector1.CargarElementoXElemento(v[i]);

            for (int i = a; i <= b; i++)
                Vector2.CargarElementoXElemento(v[i]);

            for (int i = b + 1; i <= n; i++)
                Vector3.CargarElementoXElemento(v[i]);


            Vector2.OrdenamientoBurbujaAscendente();

            Vector1.Concat(Vector2);
            Vector1.Concat(Vector3);

            this.v = Vector1.v;
            this.n = Vector1.n;
        }

        // Concatena dos vectores 
        public void Concat(Vector v1)
        {
            int n1 = v1.n;
            for (int i = 1; i <= n1; i++)
                this.CargarElementoXElemento(v1.v[i]);
        }

        // Busca El elemento Menos Repetido de un vector
        public int BuscarElementoMenosRepetido()
        {

            int leastFrequentNumber = 0;
            int minCount = int.MaxValue;

            int longitud = this.n;
            int[] vector = this.v;


            for (int i = 1; i <= longitud; i++)
            {
                int count = 0;
                int currentNumber = v[i];

                if (currentNumber == int.MinValue)
                    continue;

                for (int j = i; j <= longitud; j++)
                {
                    if (vector[j] == currentNumber)
                    {
                        count++;
                        vector[j] = int.MinValue;
                    }
                }

                if (count < minCount)
                {
                    minCount = count;
                    leastFrequentNumber = currentNumber;
                }
            }

            return leastFrequentNumber;
        }

        // Encuentra el elemento Menos repetido entre un Segmento
        public int EncontrarElementoMenosRepetidoEntreUnSegmento(int a, int b)
        {
            Vector Vector1 = new Vector();

            for (int i = a; i <= b; i++)
                Vector1.CargarElementoXElemento(v[i]);

            int menosRepetido = Vector1.BuscarElementoMenosRepetido();

            return menosRepetido;
        }

        // Encuentra la frecuencia de distribución de un segmento
        public void EncontrarLaFrecuenciaDeDistribucionEntreUnSegmento(int a, int b, ref Vector v2, ref Vector v3)
        {
            Vector Vector1 = new Vector();

            for (int i = a; i <= b; i++)
                Vector1.CargarElementoXElemento(v[i]);

            Vector1.OrdenamientoBurbujaAscendente();
            Vector Copia = new Vector();


            for (int i = 1; i <= Vector1.n; i++)
                v2.CargarElementoXElemento(Vector1.v[i]);

            v2.EliminarDuplicados();

            Vector1.CargarFrecuencia(ref v3, v2);
        }

        // Carga en un vector la frecuencia de con la que aparece un número otra frecuencia
        public void CargarFrecuencia(ref Vector v3, Vector v2)
        {
            for (int i = 1; i <= v2.n; i++)
                v3.CargarElementoXElemento(this.Frecuencia(v2.v[i]));
        }

        // Devuelve la frecuencia con la que aparece un número en un vector
        public int Frecuencia(int numero)
        {
            int c = 0;
            for (int i = 1; i <= n; i++)
                if (v[i] == numero)
                    c++;
            return c;
        }

        //public int[] EliminarDuplicados()
        //{
        //    int newSize = 0;

        //    int[] vectorSinDuplicados = new int[n + 1];

        //    for (int i = 1; i <= n; i++)
        //    {
        //        bool esDuplicado = false;

        //        for (int j = 1; j < i; j++)
        //        {
        //            if (v[i] == v[j])
        //            {
        //                esDuplicado = true;
        //                break;
        //            }
        //        }

        //        if (!esDuplicado)
        //        {
        //            vectorSinDuplicados[++newSize] = v[i];
        //        }
        //    }

        //    int[] resultado = new int[newSize];

        //    for (int i = 1; i <= newSize; i++)
        //        resultado[i] = vectorSinDuplicados[i];

        //    return resultado;
        //}

        // Segmenta un Vector Los capicuas y luego los No capicuas
        // Capicuas Ascendentemente
        // No Capicuas Descendentemente
        public void SegmentarCapicuaYNoCapicua()
        {
            int p, d;
            NEnt n1, n2;
            n1 = new NEnt();
            n2 = new NEnt();
            for (p = 1; p <= n - 1; p++)
                for (d = p + 1; d <= n; d++)
                {
                    n1.Cargar(v[d]);
                    n2.Cargar(v[p]);
                    if (n1.VerificarCapicua() && !n2.VerificarCapicua() ||
                        n1.VerificarCapicua() && n2.VerificarCapicua() && v[d] < v[p] ||
                       !n1.VerificarCapicua() && !n2.VerificarCapicua() && v[d] < v[p])

                        this.IntercambiarElementos(d, p);
                }

            int capicuas = this.ContarCapicuas();
            int NoCapicuas = this.ContarNoCapicuas();
            int longitud = this.n;
            int[] vector = this.v;

            Vector v1 = new Vector();
            Vector v2 = new Vector();
            for (int i = 1; i <= capicuas; i++)
                v1.CargarElementoXElemento(v[i]);

            for (int i = capicuas + 1; i <= this.n; i++)
                v2.CargarElementoXElemento(v[i]);

            v1.OrdenamientoBurbujaAscendente();
            v2.OrdenamientoBurbujaDescendente();

            v1.Concat(v2);

            this.v = v1.v;
            this.n = v1.n;
        }

        // Cuenta los números que son capicuas de un vector
        public int ContarCapicuas()
        {
            int contarCapicuas = 0;
            NEnt n1;
            n1 = new NEnt();

            for (int i = 1; i <= n; i++)
            {
                n1.Cargar(v[i]);
                if (!n1.VerificarCapicua())
                    break;

                contarCapicuas++;
            }
            return contarCapicuas;
        }

        // Cuenta los números que no son capicuas de un vector
        public int ContarNoCapicuas()
        {
            int contarNoCapicuas = 0;
            NEnt n1;
            n1 = new NEnt();

            for (int i = 1; i <= n; i++)
            {
                n1.Cargar(v[i]);
                if (n1.VerificarCapicua())
                    break;

                contarNoCapicuas++;
            }
            return contarNoCapicuas;
        }

        // Intercala Primos Y No primos De Un Vector
        public void IntercalarPrimoYNoPrimo()
        {
            int p, d;
            NEnt n1, n2;
            bool b = true;
            n1 = new NEnt();
            n2 = new NEnt();
            for (p = 1; p <= n - 1; p++)
            {
                if (b)
                    for (d = p + 1; d <= n; d++)
                    {
                        n1.Cargar(v[d]);
                        n2.Cargar(v[p]);
                        if (n1.VerificarPrimo2() && !n2.VerificarPrimo2() ||
                            n1.VerificarPrimo2() && n2.VerificarPrimo2() && v[d] < v[p] ||
                           !n1.VerificarPrimo2() && !n2.VerificarPrimo2() && v[d] < v[p])

                            this.IntercambiarElementos(d, p);

                    }
                else
                    for (d = p + 1; d <= n; d++)
                    {
                        n1.Cargar(v[d]);
                        n2.Cargar(v[p]);
                        if (!n1.VerificarPrimo2() && n2.VerificarPrimo2() ||
                            !n1.VerificarPrimo2() && !n2.VerificarPrimo2() && v[d] < v[p] ||
                             n1.VerificarPrimo2() && n2.VerificarPrimo2() && v[d] < v[p])

                            this.IntercambiarElementos(d, p);
                    }

                b = !b;
            }
        }

        // Intercala los primos y no primos de un Segmento
        public void IntercalarPrimoYNoPrimoDeUnSegmento(int a, int b)
        {
            Vector Vector1 = new Vector();
            Vector Vector2 = new Vector();
            Vector Vector3 = new Vector();

            for (int i = 1; i <= a - 1; i++)
                Vector1.CargarElementoXElemento(v[i]);

            for (int i = a; i <= b; i++)
                Vector2.CargarElementoXElemento(v[i]);

            for (int i = b + 1; i <= n; i++)
                Vector3.CargarElementoXElemento(v[i]);

            Vector2.OrdenamientoBurbujaAscendente();
            Vector2.IntercalarPrimoYNoPrimo();

            Vector1.Concat(Vector2);
            Vector1.Concat(Vector3);

            this.v = Vector1.v;
            this.n = Vector1.n;
        }
    }
}
