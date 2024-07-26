

using System.ComponentModel.DataAnnotations;

namespace Matricula.UI.Models.Estudiantes
{
    public class EstudianteParaMostrar
    {
        
        public int Id { get; set; }  
        
        [Required]
        public string Cedula { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        [Required]
        public int Edad { get; set; }


        [Required]
        public Sexo Sexo { get; set; }

        
    }
}
