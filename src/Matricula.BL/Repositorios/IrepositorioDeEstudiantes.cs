
using Matricula.Model.Entidades;

namespace Matricula.BL.Repositorios
{
    public interface IrepositorioDeEstudiantes
    {
        public Task<List<Estudiante>> ListaDeEstudiantesRegistrados();

        public Task<bool> RegistrarUnEstudiante(Estudiante estudiante);

        public Task<bool> EditarUnEstudiante(Estudiante estudiante);  

        public Task<Estudiante> ObtenerUnEstudiantePorId(int id);

        public Task<List<List<Estudiante>>> ObtenerHistorialFamiliar(int id);

        public Task<List<Estudiante>> ObtenerHombresRegistrados();
        public Task<List<Estudiante>> ObtenerMujeresRegistrados();

        public Task<bool> EliminarUnEstudiante(int id);

        public Task<List<Estudiante>> ObtenerEstudiantePorNombre(string nombre);
        public Task<List<Estudiante>> ObtenerEstudiantePorApellidos(string apellidos);
        public Task<List<Estudiante>> ObtenerEstudiantePorCedula(string cedula);


    }



    
}
