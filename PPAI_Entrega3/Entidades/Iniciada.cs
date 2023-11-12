﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Entidades
{
    public class Iniciada : Estado
    {
        public Iniciada(string nombre) : base(nombre)
        {
            this.Nombre = nombre;
        }


        public override void tomadaPorOperador(DateTime fechaHoraActual, Llamada llamada)
        {

            Estado nuevoEstado = crearProximoEstado();
            CambioEstado nuevoCambioEstado = crearCambioEstado(fechaHoraActual, nuevoEstado);

            llamada.setCambioEstado(nuevoCambioEstado);
            llamada.setEstadoLlamada(nuevoEstado);


        }

        public override Estado crearProximoEstado()
        {

            EnCurso nuevoEstado = new EnCurso("En Curso"); //REVISAR
            return nuevoEstado;

        }

        public override CambioEstado crearCambioEstado(DateTime fechaHoraInicio, Estado estadoEnCurso)
        {

            CambioEstado nuevoCambioEstado = new CambioEstado(fechaHoraInicio, estadoEnCurso);
            return nuevoCambioEstado;

        }
    }
}
