using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Practico_Programación_I
{
    public partial class Form1 : Form
    {
        Vector V1;
        Vector V2;
        Vector V3;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            V1 = new Vector();
            V2 = new Vector();
            V3 = new Vector();
            ResetearLabels();
        }
        private void cargarRandomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V1.CargarRandom(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
        }
        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text = V1.Descargar();
            label4.Text = "V1";
            label7.Text = "";
            label8.Text = "";

        }
        private void cargarElementoXElementoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V1 = new Vector();
            int n1 = int.Parse(Interaction.InputBox("Numero de Elementos:"));
            for (int i = 1; i <= n1; i++)
                V1.CargarElementoXElemento(int.Parse(Interaction.InputBox($"Elemento {i}:")));
        }

        private void fibonacciInvertidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int numeroDeElementos = int.Parse(Interaction.InputBox("¿Cuántos elementos quieres de la sucesion de Fibonacci?"));
            V1.Fibonacci(numeroDeElementos);
            V1.Invertir();
            textBox4.Text = V1.Descargar();
            label4.Text = "Sucesion de Fibonacci";
        }


        private void contarSubmultiplosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Concat($"El número de submultiplos es: {V1.ContarSubmultiplos()}"));
        }

        private void buscarElementoMayorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indice = int.Parse(Interaction.InputBox($"BUSCAR ELEMENTO MAYOR\nDeme un multiplo para las posiciones:"));
            MessageBox.Show(string.Concat($"El elemento mayor del vector de las posiciones multiplos de {indice} es: {V1.BuscarElementoMayor(indice)}"));
        }

        private void buscarLaMediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indice = int.Parse(Interaction.InputBox("BUSCAR LA MEDIA\nDeme un multiplo para las posiciones"));
            MessageBox.Show(string.Concat($"La media del vector de las posiciones multiplos de {indice} es: {V1.BuscarMedia(indice)}"));
        }

        private void buscarPrimosYNoPrimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V2 = new Vector();
            V1.BuscarPrimos(ref V2);
            textBox5.Text = V2.Descargar();

            V3 = new Vector();
            V1.BuscarNoPrimos(ref V3);
            textBox6.Text = V3.Descargar();

            ResetearLabels();
            label4.Text = "Vector Original";
            label5.Text = "Primos";
            label6.Text = "No primos";
        }

        private void invertirVectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetearLabels();
            V1.Invertir();
            textBox5.Text = V1.Descargar();

            textBox6.Text = "";

            label4.Text = "Vector Original";
            label5.Text = "Vector Invertido";
        }

        private void verificarElementosIgualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool booleano = V1.VerificarElementosIguales();
            if(booleano)
                MessageBox.Show(string.Concat(booleano , " - Elementos De V1 iguales"));
            else
                MessageBox.Show(string.Concat(booleano, " - Elementos De V1 No iguales"));

        }


        private void intersecciónDeConjuntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V3 = new Vector();
            V3.InterseccionDeConjuntos(V1, V2);

            if (V1.RetornarDimension() == 0 || V2.RetornarDimension() == 0)
                MessageBox.Show("Tienes que cargar el Vector V1 y el V2");
            else
            {
                ResetearLabels();
                textBox6.Text = V3.Descargar();
                label4.Text = "A";
                label5.Text = "B";
                label6.Text = "A ⋂ B";
            }
            
        }

        private void uniónDeConjuntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V3 = new Vector();
            V3.UnionDeConjuntos(V1, V2);
            textBox6.Text = V3.Descargar();

            if (V1.RetornarDimension() == 0 || V2.RetornarDimension() == 0)
                MessageBox.Show("Tienes que cargar el Vector V1 y el V2");
            else
            {
                ResetearLabels();
                label4.Text = "A";
                label5.Text = "B";
                label6.Text = "A ⋃ B";
            }
            
        }

        private void verificarSegmentoOrdenadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = int.Parse(Interaction.InputBox("Introduzca el primer limite: "));
            int b = int.Parse(Interaction.InputBox("Introduzca el segundo limite: "));

            if (a < 1 || b < 1 || a > V1.RetornarDimension() || b > V1.RetornarDimension())
                MessageBox.Show("Indice fuera de los limites");
            else
            {
                ResetearLabels();

                textBox5.Text = "";
                textBox6.Text = "";

                label4.Text = "Vector Original";
                label7.Text = string.Concat($"a = {a}");
                label8.Text = string.Concat($"b = {b}");
                MessageBox.Show(string.Concat(V1.VerificarOrdenSegmento(a, b)));
            }
           
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V2.CargarRandom(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
        }

        private void descargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox5.Text = V2.Descargar();
            label5.Text = "V2";
        }

        private void insertarVectorRespectoAUnaPosiciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V3 = new Vector();
            int posicion = int.Parse(Interaction.InputBox("Introduzca la posición a insertar: "));
            if (V1.RetornarDimension() == 0 || V2.RetornarDimension() == 0)
                MessageBox.Show("Tienes que cargar el Vector V1 y el V2");
            else if(posicion < 1 || posicion > V1.RetornarDimension())
                MessageBox.Show("Posición fuera de los limites del Vector 1");
            else
            {
                ResetearLabels();
                V3.InsertarVectorPorPosicion(V1, V2, posicion);
                textBox6.Text = V3.Descargar();

                label4.Text = "Vector1";
                label5.Text = "Vector2 a insertar";
                label6.Text = "Vector1 con el Vector2 Insertado";

                label7.Text = string.Concat($"posicion = {posicion}");
                label8.Text = "";
            }
        }

        private void eliminarElementosIndicando2PosicionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dimensionMaxima = V1.RetornarDimension();
            int a = int.Parse(Interaction.InputBox("Introduzca la primera posición"));
            int b = int.Parse(Interaction.InputBox("Introduzca la segunda posición"));

            if (a < 1 || b < 1 || a > dimensionMaxima || b > dimensionMaxima)
                MessageBox.Show("Posicion fuera de los límites");
            else
            {
                ResetearLabels();
                V1.EliminarElementosDelVectorIndicandoLasPosiciones(a, b);
                textBox5.Text = V1.Descargar();
                textBox6.Text = "";

                label4.Text = "Vector Original";
                label5.Text = "Vector sin el segmento eliminado";

                label7.Text = string.Concat($"a = {a}");
                label8.Text = string.Concat($"b = {b}");
            }
        }

        private void duplicarElementosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V1.DuplicarElementos();
            textBox5.Text = V1.Descargar();

            textBox6.Text = "";


            ResetearLabels();
            label4.Text = "Vector Original";
            label5.Text = "Vector Elementos Duplicados";
        }

        private void ordenarElementosDeUnSegmentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = int.Parse(Interaction.InputBox("Indique la primera posición del segmento"));
            int b = int.Parse(Interaction.InputBox("Indique la segundo posición del segmento"));

            if (a < 1 || b < 1 || a > V1.RetornarDimension() || b > V1.RetornarDimension())
                MessageBox.Show("Posición fuera de los limites del vector");
            else
            {
                ResetearLabels();
                V1.OrdenarElementosDeUnSegmento(a, b);
                textBox5.Text = V1.Descargar();
                label4.Text = "Vector Original";
                label5.Text = "Vector con el segmento Ordenado";
                label6.Text = "";


                label7.Text = string.Concat($"a = {a}");
                label8.Text = string.Concat($"b = {b}");
            }
        }

        private void encontrarElementoMenosRepetidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = int.Parse(Interaction.InputBox("Indique la primera posición del segmento"));
            int b = int.Parse(Interaction.InputBox("Indique la segundo posición del segmento"));
            if (a < 1 || b < 1 || a > V1.RetornarDimension() || b > V1.RetornarDimension())
                MessageBox.Show("Posición fuera de los limites del vector");
            else
            {
                ResetearLabels();
                int ElementoMenosRepetido = V1.EncontrarElementoMenosRepetidoEntreUnSegmento(a, b);

                textBox5.Text = "";
                textBox6.Text = "";

                label4.Text = "Vector Original";
                label7.Text = string.Concat($"a = {a}");
                label8.Text = string.Concat($"b = {b}");
                MessageBox.Show($"El elemento menos repetido es: {ElementoMenosRepetido}");
            }

        }

        private void encontrarLaFrecuenciaDeDistribuciónDeUnSegmentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = int.Parse(Interaction.InputBox("Indique la primera posición del segmento"));
            int b = int.Parse(Interaction.InputBox("Indique la segundo posición del segmento"));
            if (a < 1 || b < 1 || a > V1.RetornarDimension() || b > V1.RetornarDimension())
                MessageBox.Show("Posición fuera de los limites del vector");
            else
            {
                V2 = new Vector();
                V3 = new Vector();

                ResetearLabels();
                V1.EncontrarLaFrecuenciaDeDistribucionEntreUnSegmento(a, b, ref V2, ref V3);
                textBox5.Text = V2.Descargar();
                textBox6.Text = V3.Descargar();

                label4.Text = "Vector Original";
                label5.Text = "Vector Elemento (e) dentro del segmento";
                label6.Text = "Vector frecuencia de (f) los elementos del segmento";

                label7.Text = string.Concat($"a = {a}");
                label8.Text = string.Concat($"b = {b}");

            }
        }

        private void segmentarCapicuasAscendentementeYNoCapicuasDescendentementeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            V1.SegmentarCapicuaYNoCapicua();
            textBox5.Text = V1.Descargar();
            textBox6.Text = "";

            ResetearLabels();
            label4.Text = "Vector Original";
            label5.Text = "Vector Segmentado Capicuas - No Capicuas";
        }

        private void intercalarPrimosYNoPrimosOrdenadosDeUnSegmentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = int.Parse(Interaction.InputBox("Indique la primera posición del segmento"));
            int b = int.Parse(Interaction.InputBox("Indique la segundo posición del segmento"));
            if (a < 1 || b < 1 || a > V1.RetornarDimension() || b > V1.RetornarDimension())
                MessageBox.Show("Posición fuera de los limites del vector");
            else
            {
                ResetearLabels();
                V1.IntercalarPrimoYNoPrimoDeUnSegmento(a,b);
                textBox5.Text = V1.Descargar();
                textBox6.Text = "";

                label4.Text = "Vector Original";
                label5.Text = "Vector Intercalado Primos y No Primos";
                

                label7.Text = string.Concat($"a = {a}");
                label8.Text = string.Concat($"b = {b}");
            }
        }

        private void cargarElementoXElementoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            V2 = new Vector();
            int n1 = int.Parse(Interaction.InputBox("Numero de Elementos:"));
            for (int i = 1; i <= n1; i++)
                V2.CargarElementoXElemento(int.Parse(Interaction.InputBox($"Elemento {i}:")));
        }

        private void cargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            V3.CargarRandom(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
        }

        private void cargarElementoXElementoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            V3 = new Vector();
            int n1 = int.Parse(Interaction.InputBox("Numero de Elementos:"));
            for (int i = 1; i <= n1; i++)
                V3.CargarElementoXElemento(int.Parse(Interaction.InputBox($"Elemento {i}:")));
        }

        private void descargarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            textBox6.Text = V3.Descargar();
            label6.Text = "V3";
        }

        private void ResetearLabels()
        {
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";

            label7.Text = "";
            label8.Text = "";
        }

        private void ResetearTextBoxs()
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            V1 = new Vector();
            V2 = new Vector();
            V3 = new Vector();

            ResetearLabels();
            ResetearTextBoxs();
        }
    }
}
