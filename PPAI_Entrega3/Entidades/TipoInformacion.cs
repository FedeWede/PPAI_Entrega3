﻿using System;
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
        public int idTipoInformacion { get; set; }
        public string nombre { set; get; }
        public string descripcion { set; get; }

        // Constructor
        public TipoInformacion(string nombre, string descripcion)
        {
            // Inicializar atributos
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        //Metodos de Seteo

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public String getNombre()
        {
            return this.nombre;
        }
    }

}