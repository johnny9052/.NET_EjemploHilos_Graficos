using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Using para el manejo de hilos*/
using System.Threading;

namespace HilosEjemplo2_Multitarea_Graficos
{
    public partial class Form1 : Form
    {

        Thread hiloRojo;
        Thread hiloAzul;
        Random aleatorio;

        public Form1()
        {
            InitializeComponent();
            aleatorio = new Random();
        }

        private void btnRojo_Click(object sender, EventArgs e)
        {
            hiloRojo = new Thread(pintaRojo);
            hiloRojo.Start();
        }

        private void btnAzul_Click(object sender, EventArgs e)
        {
            hiloAzul = new Thread(pintaAzul);
            hiloAzul.Start();
        }

        #region funciones

        public void pintaRojo()
        {
            for (int x = 0; x < 100; x++)
            {
                /*Pen indica que sera un dibujo con lineas (Color, grosor)*/
                /*Brushes accede a la paleta de colores*/
                /*DrawRectangle(Objeto a dibujar, pos X, Pos Y, Ancho, Alto)*/
                this.CreateGraphics().
                    DrawRectangle(new Pen(Brushes.Red, 4),
                                  aleatorio.Next(0, this.Width),
                                  aleatorio.Next(0, this.Height),
                                  20, 20);
                Thread.Sleep(100);
            }

            MessageBox.Show("Rojo terminado");
        }

        public void pintaAzul()
        {
            for (int x = 0; x < 100; x++)
            {
                /*Pen indica que sera un dibujo con lineas (Color, grosor)*/
                /*Brushes accede a la paleta de colores*/
                /*DrawRectangle(Objeto a dibujar, pos X, Pos Y, Ancho, Alto)*/
                this.CreateGraphics().
                  DrawRectangle(new Pen(Brushes.Blue, 4),
                                aleatorio.Next(0, this.Width),
                                aleatorio.Next(0, this.Height),
                                20, 20);
                Thread.Sleep(100);
            }

            MessageBox.Show("Azul terminado");            
        }


        #endregion
    }
}
