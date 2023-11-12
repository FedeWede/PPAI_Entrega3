using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Entidades
{
    public class TipoInformacion
    {
        // Atributos
        [Key]
        public int Id { get; set; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }

        // Constructor
        public TipoInformacion(string nombre, string descripcion)
        {
            // Inicializar atributos
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        //Metodos de Seteo

        public void setNombre(string nombre)
        {
            this.Nombre = nombre;
        }

        public String getNombre()
        {
            return this.Nombre;
        }
    }

}
