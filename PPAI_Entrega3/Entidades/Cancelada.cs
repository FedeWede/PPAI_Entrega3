using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Entidades
{
    public class Cancelada : Estado
    {
        public Cancelada(string nombre) : base(nombre)
        {
            this.nombre = nombre;
        }

        public override CambioEstado crearCambioEstado(DateTime fechaInicio, Estado estado)
        {
            throw new NotImplementedException();
        }

        public override Estado crearProximoEstado()
        {
            throw new NotImplementedException();
        }
    }
}
