using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Entidades
{
    public class CambioEstado
    {
        // Atributos
        [Key]
        public int idCambioEstado { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public DateTime? fechaHoraFin { get; set; }
        // Relación
        public virtual Estado estado { get; set; }

        // Constructor
        public CambioEstado(DateTime fechaHoraInicio, Estado estado)
        {
            // Inicializar atributos
            this.fechaHoraInicio = fechaHoraInicio;
            // Inicializar relación
            this.estado = estado;
            this.fechaHoraFin = null;
        }

        public CambioEstado()
        {
        }

        // Métodos

        public void setFechaHoraInicio(DateTime fechaHoraInicio)
        {
            
            this.fechaHoraInicio = fechaHoraInicio;
        }
        public DateTime getFechaHoraInicio()
        {
            
            return fechaHoraInicio;
        }

        public void setFechaHoraFin(DateTime fechaHoraFin)
        {
            
            this.fechaHoraFin = fechaHoraFin;
        }

        public string getNombreEstado()
        {
            // Implementación del método
            if (estado != null)
            {
                return estado.nombre;
            }
            else
            {
                return string.Empty;
            }
        }

        public Boolean esEstadoActual()
        {
            return fechaHoraFin == null;
        }
    }
}
