using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Entidades
{
    public class InformacionCliente
    {
        // Atributos
        [Key]
        public int Id { get; set; }
        public string DatoAValidar { get; set; }

        // Relaciones
        public virtual Validacion Validacion { get; set; }
        public virtual TipoInformacion TipoInformacion { get; set; }

        // Constructor
        public InformacionCliente(string datoAValidar, Validacion validacion, TipoInformacion TipoInformacion)
        {
            // Inicializar atributos
            this.DatoAValidar = datoAValidar;

            // Inicializar relaciones
            this.Validacion = validacion;
            this.TipoInformacion = this.TipoInformacion;
        }

        public InformacionCliente() { }

        //Metodos de Seteo

        public void setDatoAValidar(string datoAValidar)
        {
            this.DatoAValidar = datoAValidar;
        }

        public String getdatoAValidar()
        {
            return this.DatoAValidar;
        }

        // Métodos      
        public bool esValidacion(string val)
        {
            bool bandera = false;
            string nombreVal = this.Validacion.Nombre;
            if (val == nombreVal)
            {
                bandera = true;
            }
            return bandera;
        }

        public bool esInformacionCorrecta(string info)
        {
            bool bandera = false;
            if (info == this.DatoAValidar)
            {
                bandera = true;
            }
            return bandera;
        }
    }
}   
