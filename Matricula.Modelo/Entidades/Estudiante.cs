using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Model.Entidades
{
    public class Estudiante
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

    public enum Sexo
    {
        Hombre = 1,
        Mujer = 2
    }
}
