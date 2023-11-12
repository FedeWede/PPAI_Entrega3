using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Entidades
{
    public class Categoria
    {
        // Atributos
        [Key]
        public int Id { get; set; }
        public string AudioMensajeOpciones { get; set; }
        public string MensajeOpciones { get; set; }
        public string Nombre { get; set; }
        public int NroOrden { get; set; }

        // Relación de agregación
        public virtual List<OpcionLlamada> Opciones { get; set; }

        // Constructor
        public Categoria(string audioMensajeOpciones, string mensajeOpciones, string nombre, int nroOrden, List<OpcionLlamada> opciones)
        {
            // Inicializar atributos
            this.AudioMensajeOpciones = audioMensajeOpciones;
            this.MensajeOpciones = mensajeOpciones;
            this.Nombre = nombre;
            this.NroOrden = nroOrden;

            // Inicializar relación
            this.Opciones = opciones;
        }

        public Categoria() { }

        //Metodos de Seteo

        public void setAudioMensajeOpciones(string audioMensajeOpciones)
        {
            this.AudioMensajeOpciones = audioMensajeOpciones;
        }

        public String getAudioMensajeOpciones()
        {
            return this.AudioMensajeOpciones;
        }
        public void setMensajeOpciones(string mensajeOpciones)
        {
            this.MensajeOpciones = mensajeOpciones;
        }

        public String getmMensajeOpciones()
        {
            return this.MensajeOpciones;
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

        // Métodos
        public List<string> getValidaciones(OpcionLlamada opcionLlamada, SubOpcionLlamada subOpcionLlamada, List<Validacion> validaciones)
        {
            // Implementación del método
            List<string> mensajes = opcionLlamada.getValidaciones(subOpcionLlamada, validaciones);
            return mensajes;
        }

        public ((int, string), string) getDescripcionCategoriaYOpcion(OpcionLlamada opcionLlamada, SubOpcionLlamada subOpcionLlamada)
        {
            (int, string) datos = opcionLlamada.getDescripcion(subOpcionLlamada);
            string nombreCat = this.getNombre();
            var datos2 = (datos, nombreCat);

            return datos2;
        }
    }
}
