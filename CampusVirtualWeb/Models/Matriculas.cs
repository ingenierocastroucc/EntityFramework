using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusVirtualWeb.Models
{
    public class Matriculas
    {
        public Guid MatriculaId { get; set; }

        public Guid AsignaturaId { get; set; }

        public string NombreAsignatura { get; set; }

        public string Profesor { get; set; }

        public string TipoInscripcion { get; set; }

        public string Semestreinscripcion { get; set; }

        public Prioridad PrioridadMatricula { get; set; }

        public DateTime FechaRegistro { get; set; }

        public virtual Asignaturas AsignaturasVirtual { get; set; }

    }

    public enum Prioridad
    {

        Baja,
        Media,
        Alta

    }
}