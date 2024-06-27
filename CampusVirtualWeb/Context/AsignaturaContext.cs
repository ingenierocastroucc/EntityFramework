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
            List<Asignaturas> asignaturasInit = new List<Asignaturas>();
            asignaturasInit.Add(new Asignaturas() { AsignaturaId = Guid.Parse("d97c9709-1b2e-4084-aee3-17094f61bf74"), NombreAsignatura = "Calculo", Nivelacion = "No", Horario = 4, ProfesorAsignatura = "Pedro Diaz", FechaRegistro = DateTime.Now });
            asignaturasInit.Add(new Asignaturas() { AsignaturaId = Guid.Parse("d97c9709-1b2e-4084-aee3-17094f61bf02"), NombreAsignatura = "Ingles", Nivelacion = "No", Horario = 2, ProfesorAsignatura = "Luisa Fernandez", FechaRegistro = DateTime.Now });

            modelBuilder.Entity<Asignaturas>(asignaturas =>
            {
                asignaturas.ToTable("Asignatura");
                asignaturas.HasKey(p => p.AsignaturaId);
                asignaturas.Property(p => p.NombreAsignatura).IsRequired().HasMaxLength(100);
                asignaturas.Ignore(p => p.Nombre);
                asignaturas.Property(p => p.Nivelacion).IsRequired().HasMaxLength(100); ;
                asignaturas.Property(p => p.Horario).IsRequired();
                asignaturas.Property(p => p.ProfesorAsignatura).IsRequired().HasMaxLength(100);
                asignaturas.Property(p => p.FechaRegistro).IsRequired();
                asignaturas.HasData(asignaturasInit);
            }
            );

            List<Matriculas> matriculasInit = new List<Matriculas>();
            matriculasInit.Add(new Matriculas() { MatriculaId = Guid.Parse("d97c9709-1b2e-4084-aee3-17094f61bf03"), NombreAsignatura = "Calculo", Profesor = "Pedro Diaz", TipoInscripcion = "Virtual", Semestreinscripcion = "Primero", AsignaturaId = Guid.Parse("d97c9709-1b2e-4084-aee3-17094f61bf74"), PrioridadMatricula = Prioridad.Media, FechaRegistro = DateTime.Now });
            matriculasInit.Add(new Matriculas() { MatriculaId = Guid.Parse("d97c9709-1b2e-4084-aee3-17094f61bf04"), NombreAsignatura = "Ingles", Profesor = "Luisa Fernandez", TipoInscripcion = "Virtual", Semestreinscripcion = "Primero", AsignaturaId = Guid.Parse("d97c9709-1b2e-4084-aee3-17094f61bf02"), PrioridadMatricula = Prioridad.Media, FechaRegistro = DateTime.Now });

            modelBuilder.Entity<Matriculas>(matriculas =>
            {
                matriculas.ToTable("Matricula");
                matriculas.HasKey(p => p.MatriculaId);
                matriculas.Property(p => p.NombreAsignatura).IsRequired().HasMaxLength(100);
                matriculas.Property(p => p.Profesor).IsRequired().HasMaxLength(100);
                matriculas.Property(p => p.TipoInscripcion).IsRequired().HasMaxLength(100);
                matriculas.Property(p => p.Semestreinscripcion).IsRequired().HasMaxLength(100);
                matriculas.HasOne(p => p.AsignaturasVirtual).WithMany(p => p.MatriculaVirtual).HasForeignKey(p => p.AsignaturaId);
                matriculas.Property(p => p.PrioridadMatricula).IsRequired();
                matriculas.Property(p => p.FechaRegistro).IsRequired();
                matriculas.HasData(matriculasInit);
            }
            );
        }
    }
}
