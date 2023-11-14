using Microsoft.EntityFrameworkCore;
using PPAI_Entrega3.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Entrega3.Persistencia
{
    internal class IVRContexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=E:\PPAI Entrega 2\PPAI_Entrega3\PPAI_Entrega3\PPAI_Entrega3\IvrDB.db");
        }
        
        public DbSet<CambioEstado> CambioEstado { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<InformacionCliente> InformacionCliente { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Llamada> Llamada { get; set; }
        public DbSet<OpcionLlamada> opcionLlamada { get; set; }
        public DbSet<SubOpcionLlamada> SubOpcionLlamada { get; set; }
        public DbSet<TipoInformacion> TipoInformacion { get; set; }
        public DbSet<Validacion> Validacion { get; set; }
        public DbSet<Cancelada> Cancelada { get; set; } 
        public DbSet<EnCurso> EnCurso { get; set; }
        public DbSet<Finalizada> Finalizada { get; set; }
        public DbSet<Iniciada>  Iniciada { get; set; }


        public void actualizarLlamada(Llamada llamada)
        {
            Entry(llamada).State = EntityState.Modified;
            SaveChanges();

        }

        public void actualizarCambioEstado(CambioEstado ce)
        {
            Entry(ce).State = EntityState.Modified; //Modifica el anterior cambio de estado en la base de datos, poniendole la FechaFin
            SaveChanges();

        }

        public void guardarNuevoCambioEstado(CambioEstado nuevoCambioEstado) 
        {
            CambioEstado.Add(nuevoCambioEstado);
            SaveChanges();
        }

        public Llamada materializarLlamada(int Id) 
        {
            Llamada llamadaDB = Llamada
                        .Include(e => e.Cliente)
                            .ThenInclude(i => i.InformacionCliente)
                                .ThenInclude(t => t.TipoInformacion)
                        .Include(e => e.OpcionLlamada)
                        .Include(e => e.SubOpcionLlamada)
                            .ThenInclude(v => v.Validaciones)
                                .ThenInclude(t => t.TipoInformacion)
                        .Include(e => e.CambiosDeEstado)
                        .Include(e => e.Estado)
                        .FirstOrDefault(e => e.Id == 1);

            return llamadaDB;

        }

        public Categoria materializarCategoria(int Id)
        {
            Categoria categoriaDB = Categoria
                    .Include(e => e.Opciones)
                    .FirstOrDefault(e => e.Id == 1);

            return categoriaDB;
        }


    }
}
