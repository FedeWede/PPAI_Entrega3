using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Entidades
{
    public class OpcionLlamada
    {
        // Atributos
        [Key]
        public int Id { get; set; }
        public string AudioMensajeSubOpciones { get; set; }
        public string MensajeSubOpciones { get; set; }
        public string Nombre { get; set; }
        public int NroOrden { get; set; }

        // Relación de agregación
        public virtual List<SubOpcionLlamada>? SubOpciones { get; set; }
        public virtual List<Validacion>? Validacion { get; set; }

        // Constructor
        public OpcionLlamada(string audioMensajeSubOpciones, string mensajeSubOpciones, string nombre, int nroOrden,
            List<SubOpcionLlamada> subOpciones, List<Validacion> validaciones)
        {
            // Inicializar atributos
            this.AudioMensajeSubOpciones = audioMensajeSubOpciones;
            this.MensajeSubOpciones = mensajeSubOpciones;
            this.Nombre = nombre;
            this.NroOrden = nroOrden;

        }

        public OpcionLlamada() { }


        //Metodos de Seteo

        public void setAudioMensajeSubOpciones(string audioMensajeSubOpciones)
        {
            this.AudioMensajeSubOpciones = audioMensajeSubOpciones;
        }

        public String getAudioMensajeSubOpciones()
        {
            return this.AudioMensajeSubOpciones;
        }
        public void setMensajeSubOpciones(string mensajeSubOpciones)
        {
            this.MensajeSubOpciones = mensajeSubOpciones;
        }

        public String getMensajeSubOpciones()
        {
            return this.MensajeSubOpciones;
        }
        public void setNombre(string nombre)
        {
            this.Nombre = nombre;
        }

        public String getNombre()
        {
            return this.Nombre;
        }
        public void setNroOrden(int nroOrden)
        {
            this.NroOrden = nroOrden;
        }

        public int getNroOrden()
        {
            return this.NroOrden;
        }

        // Método
        public (int, string) getDescripcion(SubOpcionLlamada subOpcionLlamada)
        {
            // Implementación del método
            int subOpcionSeleccionada = subOpcionLlamada.getNroOrden();
            string nombreOpcion = this.getNombre();
            var datos = (subOpcionSeleccionada, nombreOpcion);
            return datos;
        }

        public List<string> getValidaciones(SubOpcionLlamada subOpcionLlamada, List<Validacion> validaciones)
        {
            // Implementación del método
            List<string> mensajes = subOpcionLlamada.getValidaciones(validaciones);
            return mensajes;
            
        }
    }
}
