namespace CampusVirtualWeb.Models
{
    public class Asignaturas
    {
        public Guid AsignaturaId { get; set; }

        private string NombreFinal { get; set; }

        public int IdAsignatura { get; set; }

        public string Nombre { get { return NombreFinal; } set { NombreFinal = value.Trim(); } }

        public string Nivelacion { get; set; }

        public int Horario { get; set; }

        public virtual Asignaturas AsignaturasVirtual { get; set; }
    }
}
