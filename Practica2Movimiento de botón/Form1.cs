using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica2Movimiento_de_botón
{
    //Tellez Escobar Brian Guadalupe
    //C21211400
    // 23/09/2025

    public partial class Form1 : Form
    {
        //Esta es una variable que usaremos para guardar la altura del diseño del programa para poder ocultar el panel 2 y luego restaurar la ventana con su tamano definido (principalmente por los margenes)
        private int alturacom;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelTitulo.Parent = pictureBox1; //Aqui asignamos el propietario de labelTitulo al PictureBox1 para que de esta manera poder hacer que el fondo del label sea transparente
            
            labelRespuesta.Parent = pictureBox2; //Se repitio el proceso anterior.

            buttonSi.TabStop = false; //Con esto evitamos que los botones puedan seleccionarse al presionar "Tab"
            buttonNo.TabStop = false;

            panel2.Hide(); //Al momento de cargar el formulario el panel2 se oculta para mejor comodidad de la interfaz del usuario (mejorar la apariencia y eso)
            alturacom = this.Height; //Se guarda la altura del forms en la variable

            this.Height = panel1.Bottom + panel1.Top; //Con esto se reduce la altura del forms para que solo se muestre el primer panel (para tener una mejor apariencia)
        }

        Random r = new Random(); //Esto lo utilizamos para poder generar numeros aleatorios que nos servira a continuacion.


        private void MoverBoton () //Este sera nuestro metodo para poder mover el boton SI a una posicion aleatoria
        {
            int x = r.Next(0, this.Width - buttonSi.Width); //Se genera una coordenada X aleatoria (esto dentro del ancho de la ventana del forms)
            int y = r.Next(0, this.Height - buttonSi.Height); //Lo mismo que el anterior punto pero ahora para la coordenada Y (dentro de la altura de la ventana)

            buttonSi.Location = new Point(x, y); //Se aplica las nuevas coordenadas generadas al boton para de esta manera moverlo.
        }

        private void buttonSi_MouseMove(object sender, MouseEventArgs e) //Se activa este evento cuando el cursor pasa encima del boton y manda a llamar el metodo MoverBoton()
        {
            MoverBoton();
        }

        private void buttonNo_Click(object sender, EventArgs e) //Evento que se activa cuando el usuario da click sobre el boton NO
        {
            this.Height = alturacom; //Se vuelve a restaurar la altura original del formulario para poder mostrar el panel2
            panel2.Show(); //Se muestra el segundo panel
        }

        private void pictureBox3_Click(object sender, EventArgs e) //Este evento cuando el usuario hace click sobre la imagen (en este caso un gif) hace que el programa se cierre
        {
            Application.Exit();
        }
    }
}
