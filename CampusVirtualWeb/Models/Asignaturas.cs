using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        public DateTime FechaRegistro { get; set; }

        [JsonIgnore]
        public virtual ICollection<Matriculas> MatriculaVirtual { get; set; }
    }
}
