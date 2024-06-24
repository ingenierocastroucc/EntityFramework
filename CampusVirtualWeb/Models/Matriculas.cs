using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusVirtualWeb.Models
{
    public class Matriculas
    {
        [Key]
        public Guid MatriculaId { get; set; }

        [ForeignKey("AsignaturaId")]
        public Guid AsignaturaId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Supera el numero de 100 caracteres permitidos"), MinLength(5, ErrorMessage = "Es inferior al numero minimo de 5 caracteres permitidos")]
        public string NombreAsignatura { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Supera el numero de 100 caracteres permitidos"), MinLength(5, ErrorMessage = "Es inferior al numero minimo de 5 caracteres permitidos")]
        public string Profesor { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Supera el numero de 100 caracteres permitidos"), MinLength(5, ErrorMessage = "Es inferior al numero minimo de 5 caracteres permitidos")]
        public string TipoInscripcion { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Supera el numero de 100 caracteres permitidos"), MinLength(5, ErrorMessage = "Es inferior al numero minimo de 5 caracteres permitidos")]
        public string Semestreinscripcion { get; set; }

        public Prioridad PrioridadMatricula { get; set; }

        public DateTime FechaRegistro { get; set; }

        [NotMapped]
        public virtual ICollection<Asignaturas> AsignaturasVirtual { get; set; }
    }

    public enum Prioridad
    {

        Baja,
        Media,
        Alta

    }
}