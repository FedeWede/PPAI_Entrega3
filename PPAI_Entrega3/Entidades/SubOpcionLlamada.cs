﻿using System;
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
        public int idSubOpcionLLamada { get; set; }
        public string nombre { get; set; }
        public int nroOrden { get; set; }

        // Relación
        public virtual ICollection<Validacion> validaciones { get; set; }

        // Constructor
        public SubOpcionLlamada(string nombre, int nroOrden, List<Validacion> validaciones)
        {
            // Inicializar atributos
            this.nombre = nombre;
            this.nroOrden = nroOrden;

            // Inicializar relación
            this.validaciones = validaciones;
        }

        public SubOpcionLlamada() { }
        //Metodos de Seteo

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public void setNroOrden(int nroOrden)
        {
            this.nroOrden = nroOrden;
        }

        public int getNroOrden()
        {
            return this.nroOrden;
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
