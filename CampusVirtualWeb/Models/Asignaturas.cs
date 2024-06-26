using System.ComponentModel.DataAnnotations;

namespace CampusVirtualWeb.Models
{
    public class Asignaturas
    {
        public Guid AsignaturaId { get; set; }

        public string NombreAsignatura { get; set; }

        public string Nombre { get { return NombreAsignatura; } set { NombreAsignatura = value.Trim(); } }

        public string Nivelacion { get; set; }

        public string ProfesorAsignatura { get; set; }

        public int Horario { get; set; }

        public virtual ICollection<Matriculas> MatriculaVirtual { get; set; }
    }
}
