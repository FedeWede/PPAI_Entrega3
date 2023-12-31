﻿using PPAI_Entrega3.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_Entrega3.Interfaces;
using PPAI_Entrega3.NewFolder1;
using System.Windows.Forms;

namespace PPAI_Entrega3.Gestor
{
    public class GestorRegistrarRespuesta
    {
        public List<string> DatosLlamada { get; set; }
        public string FechaHoraActual { get; set; }
        public string RespuestaSeleccionada { get; set; }
        public string OpValidacion { get; set; }
        public Llamada LlamadaSeleccionada { get; set; }

        public GestorRegistrarRespuesta(InterfazRegistrarRespuesta interfazRegistrarLlamada)
        {
            this.FechaHoraActual = obtenerFechaHoraActual();
            this.interfazRegistrarLlamada = interfazRegistrarLlamada;

        }
        public GestorRegistrarRespuesta(List<string> datosLlamada, string fechaHoraActual, string respuestaSeleccionada, string opValidacion)
        {
            this.DatosLlamada = datosLlamada;
            this.FechaHoraActual = fechaHoraActual;
            this.RespuestaSeleccionada = respuestaSeleccionada;
            this.OpValidacion = opValidacion;
        }

        public GestorRegistrarRespuesta(InterfazIVR interfazIVR)
        {
            this.interfazIVR = interfazIVR;
        }


        //Relaciones
        public InterfazRegistrarRespuesta interfazRegistrarLlamada;
        public GestorRegistrarLlamada gestorRegistrarLlamada;
        public Llamada llamada;
        public Categoria categoria;
        public Estado estado;
        public InterfazIVR interfazIVR;

        // Métodos
        public string obtenerFechaHoraActual()
        {
            DateTime fechaHoraActual = DateTime.Now;

            string fechaHoraString = fechaHoraActual.ToString();

            return fechaHoraString;
        }

        // El controlador recibe los datos de la llamada e inicia la ejecución del CU:
        public void nuevaRespuestaOperador(Llamada llamada1, Categoria categoria)
        {
            LlamadaSeleccionada = llamada1;
            string tiempo1 = obtenerFechaHoraActual();
            llamada1.tomadaPorOperador(tiempo1);
            buscarDatosLlamada(llamada1, categoria);
            InterfazRegistrarRespuesta interfazRegistrarLlamada = new InterfazRegistrarRespuesta(llamada1, this);
            interfazRegistrarLlamada.mostrarDatos(DatosLlamada);
            // Cuando se cierre la interfaz:
            string tiempo2 = obtenerFechaHoraActual();
            llamada1.calcularDuracion(tiempo1, tiempo2);
            llamada1.setDescripcionOperador(RespuestaSeleccionada);
            llamada1.finalizar(tiempo2); // se crea el estado finalizada
            finCU();
        }

        public void buscarDatosLlamada(Llamada llamada, Categoria categoria)
        {
            this.DatosLlamada = new List<string>();

            string nombreCliente = llamada.getCliente(); // Mostrar
            DatosLlamada.Add(nombreCliente);
            ;

            ((int, string), string) tupla = categoria.getDescripcionCategoriaYOpcion(llamada.OpcionLlamada, llamada.SubOpcionLlamada);

            string nombreCate = tupla.Item1.Item2; // Mostrar
            DatosLlamada.Add(nombreCate);
            string nombreOpcion = tupla.Item1.Item2; // Mostrar
            DatosLlamada.Add(nombreOpcion);
            int nroOrden = tupla.Item1.Item1; // Mostrar
            DatosLlamada.Add(nroOrden.ToString());


            List<string> mensajes = categoria.getValidaciones(llamada.OpcionLlamada, llamada.SubOpcionLlamada, llamada.SubOpcionLlamada.Validaciones); // Mostrar

            foreach (string mensaje in mensajes) DatosLlamada.Add(mensaje);

            string fechaHora = obtenerFechaHoraActual();
            DatosLlamada.Add(fechaHora);

            foreach (string mensaje in mensajes)
            {
                this.OpValidacion = llamada.Cliente.buscarInfoCorrecta(llamada, mensaje);
                DatosLlamada.Add(OpValidacion);
            }
        }

        public bool tomarOpValidacion(string respuesta, string validacion, Llamada llamada)
        {

            bool bandera = llamada.validarInformacionCliente(respuesta, validacion, llamada);
            return bandera;
        }

        public void tomarRespuesta(string res)
        {
            string respuesta = res;

            this.RespuestaSeleccionada = res;
        }
        public string tomarAccion(string acc)
        {
            LlamadaSeleccionada.DetalleAccionRequerida = acc;
            string accion = acc;
            return accion;
        }

        public void tomarConfirmacion(string accion)
        {
            llamadaCU28(accion);

        }

        public void llamadaCU28(string accion)
        {
            // Retornaría true si la llamada se ejecuta con éxito y false en el caso contrario.
            GestorCU28 gestorCU28 = new GestorCU28(accion);
            MessageBox.Show("CU28 finalizado exitosamente!");
        }

        public void cancelar()
        {
            string tiempo = obtenerFechaHoraActual();
            LlamadaSeleccionada.cancelar(tiempo);

        }

        public void finCU()
        {

        }
    }
}

