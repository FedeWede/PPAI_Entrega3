using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Entidades
{
    public class SubOpcionLlamada
    {
        // Atributos
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int NroOrden { get; set; }

        // Relación
        public virtual List<Validacion> Validaciones { get; set; }

        // Constructor
        public SubOpcionLlamada(string nombre, int nroOrden, List<Validacion> validaciones)
        {
            // Inicializar atributos
            this.Nombre = nombre;
            this.NroOrden = nroOrden;

            // Inicializar relación
            this.Validaciones = validaciones;
        }

        public SubOpcionLlamada() { }
        //Metodos de Seteo

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
    

        public List<string> getValidaciones(List<Validacion> validaciones)
        {
            // Implementación del método
            List<string> mensajes = new List<string>();
            
            foreach (Validacion v in validaciones)
            {
                string mens = v.getMensaje();
                mensajes.Add(mens);
                
            }
            return mensajes;
        }
    }

   

}
