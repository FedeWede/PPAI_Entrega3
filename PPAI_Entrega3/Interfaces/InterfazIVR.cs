using PPAI_Entrega3.Gestor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI_Entrega3.Interfaces;
using PPAI_Entrega3.Entidades;

namespace PPAI_Entrega3.NewFolder1
{
    public partial class InterfazIVR : Form
    {
        //Relaciones

        public GestorRegistrarLlamada gestorRegistrarLlamada;

        public GestorRegistrarRespuesta gestorRegistrarRespuesta;

        public InterfazIVR()
        {
            
            gestorRegistrarLlamada = new GestorRegistrarLlamada(this);
            gestorRegistrarRespuesta = new GestorRegistrarRespuesta(this);


            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void InterfazIVR_Load(object sender, EventArgs e)
        {
            (Llamada llamada, Categoria categoria) = gestorRegistrarLlamada.opcionNuevaRespuestaOperador();

        }

        public void MostrarDNI(string dni)
        {
            textBox1.Text = dni;
        }

        public void MostrarCategoria(int categoria, string nombre)
        {
            string textoAMostrar = categoria.ToString() + ": " + nombre;
            textBox2.Text = textoAMostrar;
        }

        public void MostrarOpcion(int opcion, string nombre)
        {
            string textoAMostrar = opcion.ToString() + ": " + nombre;
            textBox3.Text = textoAMostrar;
        }

        public void MostrarSubopcion(int subopcion, string nombre)
        {
            string textoAMostrar = subopcion.ToString() + ": " + nombre;
            textBox4.Text = textoAMostrar;
        }

        // Con este botón simulamos que el cliente selecciona la opción Hablar con operador:
        private void button5_Click(object sender, EventArgs e)
        {
            (Llamada llamada1, Categoria categoria) = gestorRegistrarLlamada.opcionNuevaRespuestaOperador();
            this.gestorRegistrarRespuesta.nuevaRespuestaOperador(llamada1,categoria);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}