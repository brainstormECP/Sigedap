using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Sigedap.Models
{
    public class SigedapContext : IdentityDbContext<Usuario>
    {
        public SigedapContext()
            : base("sigedap")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expediente>()
                .HasRequired(d => d.DictamenDeReclamacion)
                .WithRequiredDependent(e => e.Expediente);
            modelBuilder.Entity<ActaRecogidaEquipos>()
                .HasRequired(d => d.Expediente)
                .WithRequiredDependent(e => e.ActaRecogidaEquipos);
            modelBuilder.Entity<ActaDevolucion>()
                .HasRequired(d => d.Expediente)
                .WithRequiredDependent(e => e.ActaDevolucion);
            modelBuilder.Entity<SolicitudReposicion>()
                .HasRequired(d => d.Expediente)
                .WithRequiredDependent(e => e.SolicitudReposicion);
            modelBuilder.Entity<DictamenTecnico>()
                .HasRequired(d => d.EquipoDañado)
                .WithRequiredDependent(e => e.DictamenTecnico);
            modelBuilder.Entity<Expediente>()
                .HasRequired(e => e.Inspector)
                .WithMany(i => i.Expedientes)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Expediente>()
                .HasRequired(e => e.Despachador)
                .WithMany(i => i.Expedientes)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Expediente>()
                .HasRequired(e => e.Operario)
                .WithMany(i => i.Expedientes)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<EquipoDañado>()
                .HasRequired(e => e.ExpedienteDictamenDeReclamacion)
                .WithMany(ex => ex.EquiposDañados);
            modelBuilder.Entity<EquipoNuevo>().HasOptional(e => e.EquipoDañado).WithOptionalPrincipal(e => e.EquipoNuevo);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Expediente> Expedientes { get; set; }

        public DbSet<Trabajador> Trabajadores { get; set; }
        
        public DbSet<DictamenDeReclamacion> DictamenesDeReclamacion { get; set; }

        public DbSet<DictamenTecnico> DictamenesTecnicos { get; set; }

        public DbSet<DictamenPorPartes> DictamenesPorPartes { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<TipoDeEquipo> TiposDeEquipos { get; set; }

        public DbSet<EquipoNuevo> EquiposNuevos { get; set; }

        public DbSet<EquipoDañado> EquiposDañados { get; set; }

        public DbSet<ActaDevolucion> ActasDevoluciones { get; set; }

        public DbSet<ActaEntregaEquiposReposicion> ActasEntregaEquiposReposicion { get; set; }

        public DbSet<ActaRecogidaDestruir> ActasRecogidaDestruir { get; set; }

        public DbSet<ActaRecogidaEquipos> ActasRecogidaEquipos { get; set; }

        public DbSet<Despachador> Despachadores { get; set; }

        public DbSet<Operario> Operarios { get; set; }

        public DbSet<Inspector> Inspectores { get; set; }

        public DbSet<SolicitudReposicion> SolicitudesReposicion { get; set; }
    }
}