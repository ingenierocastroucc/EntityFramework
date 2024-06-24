using System.ComponentModel.DataAnnotations;

namespace CampusVirtualWeb.Models
{
    public class Asignaturas
    {
        [Key]
        public Guid AsignaturaId { get; set; }

        [Required]
        [MaxLength(100)]
        private string NombreFinal { get; set; }

        [Required]
        public int IdAsignatura { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Supera el numero de 100 caracteres permitidos"), MinLength(5, ErrorMessage = "Es inferior al numero minimo de 5 caracteres permitidos")]
        public string Nombre { get { return NombreFinal; } set { NombreFinal = value.Trim(); } }

        public string Nivelacion { get; set; }

        [Required, ConcurrencyCheck]
        public int Horario { get; set; }

        public virtual Asignaturas AsignaturasVirtual { get; set; }
    }
}
