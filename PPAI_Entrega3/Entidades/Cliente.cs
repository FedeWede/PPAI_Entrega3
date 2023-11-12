﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Entidades
{
    public class Cliente
    {
        // Atributos
        [Key]
        public int IdCliente { get; set; }
        public string dni { get; set; }
        public string nombreCompleto { get; set; }
        public string numeroCelular { get; set; }


        // Relación
        public virtual ICollection<InformacionCliente> informacionCliente { get; set; }

        // Constructor
        public Cliente(string dni, string nombreCompleto, string numeroCelular, List<InformacionCliente> informacionCliente)
        {
            // Inicializar atributos
            this.dni = dni;
            this.nombreCompleto = nombreCompleto;
            this.numeroCelular = numeroCelular;

            // Inicializar relación
            this.informacionCliente = informacionCliente; // Cambiado por el new
        }

        public Cliente() { }

        //Metodos de Seteo
        public void setDni(string dni)
        {
            this.dni = dni;
        }

        public String getDni()
        {
            return this.dni;
        }
        public void setNombreCompleto(string nombreCompleto)
        {
            this.nombreCompleto = nombreCompleto;
        }

        public String getNombreClienteLlamada()
        {
            return this.nombreCompleto;
        }

        public void setNumeroCelular(string numeroCelular)
        {
            this.numeroCelular = numeroCelular;
        }

        public String getNumeroCelular()
        {
            return this.numeroCelular;
        }

        // Métodos
          
        public bool esInformacionCorrecta(string info, string validacion, Llamada llamada)
        {
            bool bandera = false;
            foreach (InformacionCliente informacionCliente in llamada.cliente.informacionCliente)
            {
                if (informacionCliente.esValidacion(validacion) == true)
                {   
                    if(informacionCliente.esInformacionCorrecta(info))
                    {
                        bandera = true;
                        break;
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    
                }
            }
            return bandera;
        }

        public string buscarInfoCorrecta(Llamada llamada, string validacion)
        {
            string correcta = "No hay correcta";
            foreach (InformacionCliente informacionCliente in llamada.cliente.informacionCliente)
            {
                if (informacionCliente.esValidacion(validacion) == true)
                {
                    correcta = informacionCliente.getdatoAValidar();
                    break;
                }
                else 
                {
                    correcta = "No hay correcta";
                }
            }
            return correcta;
        } 
    } 
}


