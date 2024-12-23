using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.ComponentModel.DataAnnotations;

namespace Matricula.UI.Models.Estudiantes
{
    public class EstudianteParaAgregar
    {

            public int Id { get; set; } 

            [Required]
            public string Cedula { get; set; }

            [Required]
            public string Nombre { get; set; }

            [Required]
            public string PrimerApellido { get; set; }

            [Required]
            public string SegundoApellido { get; set; }

            [Required]
            public DateTime FechaDeNacimiento { set; get; }

            [Required]
            public Sexo Sexo { get; set; }

            [Required]
            public string CedulaPadre { get; set; }

            [Required]
            public string CedulaMadre { get; set; }

        }


    }

