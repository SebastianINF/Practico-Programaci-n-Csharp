using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Programación_I
{
    class NEnt
    {
        private int entero;

        public NEnt()
        {
            entero = 0;
        }

        public bool VerificarPrimo(int numero)
        {
            int i, c, r;
            c = 0;
            for (i = 1; i <= numero; i++)
            {
                r = numero % i;
                if (r == 0)
                    c++;
            }
            return c == 2;
        }

        public bool VerificarPrimo2()
        {
            int i, c, r;
            c = 0;
            for (i = 1; i <= this.entero; i++)
            {
                r = this.entero % i;
                if (r == 0)
                    c++;
            }
            return c == 2;
        }

        public void Cargar(int numero)
        {
            this.entero = numero;
        }

        public bool VerificarPar()
        {
            return entero % 2 == 0;
        }

        public void Invertir()
        {
            int digito;
            int resultado = 0;
            int numero = this.entero;
            while (numero > 0)
            {
                digito = numero % 10;
                resultado = resultado * 10 + digito;
                numero /= 10;
            }
            this.entero = resultado;
        }

        public bool VerificarCapicua()
        {
            int capicua = this.entero;
            this.Invertir();
            return capicua == this.entero;
        }
    }
}
