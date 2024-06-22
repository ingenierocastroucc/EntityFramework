using CampusVirtualWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusVirtualWeb.Context
{
    public class AsignaturaContext : DbContext
    {
        public DbSet<Asignaturas> AsignaturasVirtual { get; set; }
        public DbSet<Matriculas> Matriculas { get; set; }

        public AsignaturaContext(DbContextOptions<AsignaturaContext> options) : base(options) { }
    }
}
