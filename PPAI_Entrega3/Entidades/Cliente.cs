using System;
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
        public int Id { get; set; }
        public string Dni { get; set; }
        public string NombreCompleto { get; set; }
        public string? NumeroCelular { get; set; }


        // Relación
        public virtual List<InformacionCliente> InformacionCliente { get; set; }

        // Constructor
        public Cliente(string dni, string nombreCompleto, string numeroCelular, List<InformacionCliente> informacionCliente)
        {
            // Inicializar atributos
            this.Dni = dni;
            this.NombreCompleto = nombreCompleto;
            this.NumeroCelular = numeroCelular;

            // Inicializar relación
            this.InformacionCliente = informacionCliente; // Cambiado por el new
        }

        public Cliente() { }

        //Metodos de Seteo
        public void setDni(string dni)
        {
            this.Dni = dni;
        }

        public String getDni()
        {
            return this.Dni;
        }
        public void setNombreCompleto(string nombreCompleto)
        {
            this.NombreCompleto = nombreCompleto;
        }

        public String getNombreClienteLlamada()
        {
            return this.NombreCompleto;
        }

        public void setNumeroCelular(string numeroCelular)
        {
            this.NumeroCelular = numeroCelular;
        }

        public String getNumeroCelular()
        {
            return this.NumeroCelular;
        }

        // Métodos
          
        public bool esInformacionCorrecta(string info, string validacion, Llamada llamada)
        {
            bool bandera = false;
            foreach (InformacionCliente informacionCliente in llamada.Cliente.InformacionCliente)
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
            foreach (InformacionCliente informacionCliente in llamada.Cliente.InformacionCliente)
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



