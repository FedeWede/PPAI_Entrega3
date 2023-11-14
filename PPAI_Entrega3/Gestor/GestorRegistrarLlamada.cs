using PPAI_Entrega3.Entidades;
using PPAI_Entrega3.Interfaces;
using PPAI_Entrega3.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI_Entrega3.Servicios;
using PPAI_Entrega3.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace PPAI_Entrega3.Gestor
{
    public class GestorRegistrarLlamada
    {
        private readonly InterfazIVR interfaz;

        // Constructor que recibe la instancia del formulario
        public GestorRegistrarLlamada(InterfazIVR interfaz)
        {

            this.interfaz = interfaz;
        }

        // relaciones
        public InterfazIVR interfazIVR;
        public GestorRegistrarRespuesta gestorRegistrarRespuesta;
        public InterfazRegistrarRespuesta interfazRegistrarLlamada;

        //Simulamos el fin del CU Registrar Llamada, trayendo una llamada desde la base de datos
        public void opcionNuevaRespuestaOperador(int IdLlamada, int IdCategoria)
        {
            Llamada llamadaDB;
            Categoria categoriaDB;


            using (var contexto = new IVRContexto())
            {
                llamadaDB = contexto.materializarLlamada(IdLlamada);
                categoriaDB = contexto.materializarCategoria(IdCategoria);

            }

            interfaz.gestorRegistrarRespuesta.nuevaRespuestaOperador(llamadaDB, categoriaDB);
        }

        public (int, int) iniciarCU()
        {
            Llamada llamadaDB;
            Categoria categoriaDB;
            using (var contexto = new IVRContexto())
            {
                llamadaDB = contexto.materializarLlamada(1);
                categoriaDB = contexto.materializarCategoria(1);
            }            


                interfaz.MostrarDNI(llamadaDB.Cliente.Dni);
                interfaz.MostrarCategoria(categoriaDB.NroOrden, categoriaDB.Nombre);
                interfaz.MostrarOpcion(categoriaDB.Opciones[0].SubOpciones[0].NroOrden, categoriaDB.Opciones[0].SubOpciones[0].Nombre);
                interfaz.MostrarSubopcion(categoriaDB.Opciones[0].NroOrden, categoriaDB.Opciones[0].Nombre);

            return (llamadaDB.Id, categoriaDB.Id);

        }
    }
}