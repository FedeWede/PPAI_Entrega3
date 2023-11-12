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
        public int Id { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime? FechaHoraFin { get; set; }

        // Relación
        public virtual Estado Estado { get; set; }

        // Constructor
        public CambioEstado(DateTime fechaHoraInicio, Estado estado)
        {
            // Inicializar atributos
            this.FechaHoraInicio = fechaHoraInicio;
            // Inicializar relación
            this.Estado = estado;
        }

        public CambioEstado()
        {
        }

        // Métodos

        public void setFechaHoraInicio(DateTime fechaHoraInicio)
        {
            
            this.FechaHoraInicio = fechaHoraInicio;
        }
        public DateTime getFechaHoraInicio()
        {
            
            return FechaHoraInicio;
        }

        public void setFechaHoraFin(DateTime fechaHoraFin)
        {
            
            this.FechaHoraFin = fechaHoraFin;
        }

        public string getNombreEstado()
        {
            // Implementación del método
            if (Estado != null)
            {
                return Estado.Nombre;
            }
            else
            {
                return string.Empty;
            }
        }

        public Boolean esEstadoActual()
        {
            return FechaHoraFin == null;
        }
    }
}
