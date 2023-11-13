using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_Entrega3.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace PPAI_Entrega3.Entidades
{
    public class Iniciada : Estado
    {
        public Iniciada(string nombre) : base(nombre)
        {
            this.Nombre = nombre;
        }


        public string Nombre { get; set; }


        public override void tomadaPorOperador(DateTime fechaHoraActual, Llamada llamada, List<CambioEstado> cambiosEstado)
        {
            CambioEstado ce = buscarUltimoEstado(cambiosEstado);
            ce.setFechaHoraFin(fechaHoraActual); // ACCESO A BD

            Estado nuevoEstado = crearProximoEstado(); //ACCESO BD
            CambioEstado nuevoCambioEstado = crearCambioEstado(fechaHoraActual, nuevoEstado); // ACCESO BD

            llamada.setCambioEstado(nuevoCambioEstado); // ACCESO BD
            llamada.setEstadoLlamada(nuevoEstado); // ACCESO BD

            using (IVRContexto context = new IVRContexto())
            {
                context.Entry(ce).State = EntityState.Modified;
                context.CambioEstado.Add(nuevoCambioEstado);

                context.Entry(llamada).State = EntityState.Modified;
                context.SaveChanges();

            };



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
