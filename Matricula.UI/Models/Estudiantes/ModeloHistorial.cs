using Matricula.Model.Entidades;

namespace Matricula.UI.Models.Estudiantes
{
    public class ModeloHistorial
    {
        public Estudiante Estudiante { get; set; }
        public List<List<Estudiante>> Historial { get; set; }
    }
}
