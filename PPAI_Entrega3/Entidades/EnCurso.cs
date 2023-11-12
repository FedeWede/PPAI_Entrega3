using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Entidades
{
    public class EnCurso : Estado
    {
        public EnCurso(string nombre) : base(nombre)
        {
            this.Nombre = nombre;
        }

        public override void finalizar(DateTime fechaHoraActual, Llamada llamada, List<CambioEstado> cambiosestado)
        {
            CambioEstado ce = buscarUltimoEstado(cambiosestado);
            ce.setFechaHoraFin(fechaHoraActual);

            Estado nuevoEstado = crearProximoEstado();
            CambioEstado nuevoCambioEstado = crearCambioEstado(fechaHoraActual, nuevoEstado);

            llamada.setCambioEstado(nuevoCambioEstado);
            llamada.setEstadoLlamada(nuevoEstado);
        
        }

        public override Estado crearProximoEstado()
        {
            Finalizada nuevoEstado = new Finalizada("Finalizada"); //REVISAR
            return nuevoEstado;

        }

        public override CambioEstado crearCambioEstado(DateTime fechaHoraInicio, Estado estado)
        {
            CambioEstado nuevoCambioEstado = new CambioEstado(fechaHoraInicio, estado);
            return nuevoCambioEstado;
               
        }

    }
}
