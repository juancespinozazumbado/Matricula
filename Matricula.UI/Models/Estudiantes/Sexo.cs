using System.ComponentModel.DataAnnotations;

namespace Matricula.UI.Models.Estudiantes
{
    public enum Sexo
    {
        [Display(Name = "Masculino")]
        Masculino = 1,
        [Display(Name = "Femenino")]
        Fememina = 2
    }
}
