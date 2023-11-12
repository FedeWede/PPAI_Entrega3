using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Entidades
{
    public class Validacion
    {
        // Atributos
        [Key]
        public int Id { get; set; }
        public string AudioMensajeValidacion { get; set; }
        public string Nombre { get; set; }
        public int NroOrden { get; set; }

        // Relación
        public virtual TipoInformacion TipoInformacion { get; set; }

        // Constructor
        public Validacion(string audioMensajeValidacion, string nombre, int nroOrden, TipoInformacion tipoInformacion)
        {
            // Inicializar atributos
            this.AudioMensajeValidacion = audioMensajeValidacion;
            this.Nombre = nombre;
            this.NroOrden = nroOrden;
            

            // Inicializar relación
           this.TipoInformacion = tipoInformacion;
        }

        public Validacion() { }

        // Método
        public string getMensaje()
        {
            // Implementación del método
            return this.Nombre;
        }
    }

  

}
