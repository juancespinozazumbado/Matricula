

using Matricula.AppMovil.Models;

namespace Matricula.AppMovil.Servicios.Iservicios
{
    public interface IServicioDeEstudiantes
    {
        public Task<List<Estudiante>> ListaDeEstudiantesRegistrados();


        //public Task<Estudiante> ObtenerUnEstudiantePorId(int id);

        //public Task<List<List<Estudiante>>> ObtenerHistorialFamiliar(int id);

        public Task<List<Estudiante>> ObtenerHombresRegistrados();
        public Task<List<Estudiante>> ObtenerMujeresRegistrados();



    }

}
