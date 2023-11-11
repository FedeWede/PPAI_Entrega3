using PPAI_Entrega3.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Servicios
{
    public class Servicios
    {
        public string fechas { get; set; }

        public Servicios()
        {

            
        }

        public DateTime[] GenerarFechasAleatorias(DateTime startDate, DateTime endDate, int cantidad)
        {
            Random random = new Random();
            TimeSpan range = endDate - startDate;
            DateTime[] fechas = new DateTime[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                int randomDays = random.Next(range.Days);
                fechas[i] = startDate.AddDays(randomDays);
            }

            return fechas;
        }
    }
}


