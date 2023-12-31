﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Entidades
{
    public abstract class Estado
    {
        // Atributos
        [Key]
        public int Id { get; set;  }
        public string Nombre { get; set; }

        // Constructor
        public Estado(string nombre)
        {
            // Inicializar atributos
            this.Nombre = nombre;
        }

        /*
        public static Estado Iniciado { get; } = new Estado("Iniciada");
        public static Estado EnCurso { get; } = new Estado("EnCurso");
        public static Estado Finalizada { get; } = new Estado("Finalizada");

        public static List<Estado> estados { get; } = new List<Estado>
        {
            Iniciado, EnCurso, Finalizada
        };
        */
        public string getNombre()
        {
            return this.Nombre;
        }

        public virtual void tomadaPorOperador(DateTime fechaHoraActual, Llamada llamada, List<CambioEstado> cambioEstado) { }


        public virtual void finalizar(DateTime fechaHoraActual, Llamada llamada, List<CambioEstado> cambioEstado) { }

        public virtual void cancelar(DateTime fechaHoraActual, Llamada llamada, List<CambioEstado> cambioEstado) { }


        public abstract Estado crearProximoEstado();


        public abstract CambioEstado crearCambioEstado(DateTime fechaInicio, Estado estado);




        // Métodos
        public CambioEstado buscarUltimoEstado(List<CambioEstado> cambiosEstado)
        {
            foreach (CambioEstado ce in cambiosEstado)
            {
                if (ce.esEstadoActual())
                {
                    return ce;
                }
            }
            return null;
        }
        /*
        public static Estado esEnCurso()
        {
            foreach (Estado estado in estados)
            {
                if (estado.nombre == "EnCurso")
                {
                    return estado;
                }
            }
            return null;
        }
        
        public static Estado esFinalizada()
        {
            foreach (Estado estado in estados)
            {
                if (estado.nombre == "Finalizada")
                {
                    return estado;
                }
            }
            return null;
        }

        public bool esIniciada()
        {
            if (this.nombre == "Ïniciada")
            {
                return true;
            }
            return false;
        }
       */
    }

}
