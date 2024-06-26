using CampusVirtualWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusVirtualWeb.Context
{
    public class AsignaturaContext : DbContext
    {
        public DbSet<Asignaturas> AsignaturasVirtual { get; set; }
        public DbSet<Matriculas> MatriculaVirtual { get; set; }

        public AsignaturaContext(DbContextOptions<AsignaturaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            modelBuilder.Entity<Asignaturas>(asignaturas =>
            {
                asignaturas.ToTable("Asignatura");
                asignaturas.HasKey(p => p.AsignaturaId);
                asignaturas.Property(p => p.NombreAsignatura).IsRequired().HasMaxLength(100);
                asignaturas.Ignore(p => p.Nombre);
                asignaturas.Property(p => p.Horario).IsRequired();
                asignaturas.Property(p => p.ProfesorAsignatura).IsRequired().HasMaxLength(100);
            }
            );
            modelBuilder.Entity<Matriculas>(matriculas =>
            {
                matriculas.ToTable("Matricula");
                matriculas.HasKey(p => p.MatriculaId);
                matriculas.Property(p => p.NombreAsignatura).IsRequired().HasMaxLength(100);
                matriculas.Property(p => p.Profesor).IsRequired().HasMaxLength(100);
                matriculas.Property(p => p.TipoInscripcion).IsRequired().HasMaxLength(100);
                matriculas.Property(p => p.Semestreinscripcion).IsRequired().HasMaxLength(100);
                matriculas.HasOne(p => p.AsignaturasVirtual).WithMany(p => p.MatriculaVirtual).HasForeignKey(p => p.AsignaturaId);
            }
            );
        }
    }
}
