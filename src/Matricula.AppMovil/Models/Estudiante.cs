
namespace Matricula.AppMovil.Models
{
    public class Estudiante
    {
        public int Id { get; set; }


        public string Cedula { get; set; }

        public string Nombre { get; set; }


        public string PrimerApellido { get; set; }


        public string SegundoApellido { get; set; }

        public DateTime FechaDeNacimiento { set; get; }

        public Sexo Sexo { get; set; }

        public string CedulaPadre { get; set; }

        public string CedulaMadre { get; set; }

    }

    public enum Sexo
    {
        Hombre = 1,
        Mujer = 2
    }


}

