﻿using System;
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
        public int idInformacionCliente { get; set; }
        public string datoAValidar { get; set; }

        // Relaciones
        public virtual Validacion validacion { get; set; }
        public virtual TipoInformacion tipoInformacion { get; set; }

        // Constructor
        public InformacionCliente(string datoAValidar, Validacion validacion, TipoInformacion TipoInformacion)
        {
            // Inicializar atributos
            this.datoAValidar = datoAValidar;

            // Inicializar relaciones
            this.validacion = validacion;
            this.tipoInformacion = tipoInformacion;
        }

        public InformacionCliente() { }

        //Metodos de Seteo

        public void setDatoAValidar(string datoAValidar)
        {
            this.datoAValidar = datoAValidar;
        }

        public String getdatoAValidar()
        {
            return this.datoAValidar;
        }

        // Métodos      
        public bool esValidacion(string val)
        {
            bool bandera = false;
            string nombreVal = this.validacion.nombre;
            if (val == nombreVal)
            {
                bandera = true;
            }
            return bandera;
        }

        public bool esInformacionCorrecta(string info)
        {
            bool bandera = false;
            if (info == this.datoAValidar)
            {
                bandera = true;
            }
            return bandera;
        }
    }
}   
