using Matricula.BL.Repositorios;
using Matricula.Model.Entidades;
using Matricula.SI.Modelos.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel;

namespace Matricula.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : Controller
    {

        private readonly IrepositorioDeEstudiantes _repositorioDeEstudiantes;

        public EstudiantesController(IrepositorioDeEstudiantes repositorioDeEstudiantes)
        {
            _repositorioDeEstudiantes = repositorioDeEstudiantes;   
        }

        [HttpGet()]
        public async Task<RespuestaRest<List<Estudiante>>> ListarEstudiantes()
        {
            var estudiantes = await _repositorioDeEstudiantes.ListaDeEstudiantesRegistrados();
            return new RespuestaRest<List<Estudiante>>()
            {
                Mensaje ="Satisfactorio",
                Respuesta = estudiantes

            };
        }

        [HttpGet("Mujeres")]
        public async Task<RespuestaRest<List<Estudiante>>> EstudiantesMujeres()
        {
            var estudiantes = await _repositorioDeEstudiantes.ObtenerMujeresRegistrados();
            return new RespuestaRest<List<Estudiante>>()
            {
                Mensaje = "Satisfactorio",
                Respuesta = estudiantes

            };
        }

        [HttpGet("Hombres")]
        public async Task<RespuestaRest<List<Estudiante>>> EstudiantesHombres()
        {
            var estudiantes = await _repositorioDeEstudiantes.ObtenerHombresRegistrados();
            return new RespuestaRest<List<Estudiante>>()
            {
                Mensaje = "Satisfactorio",
                Respuesta = estudiantes

            };
        }




        [HttpGet("Ver")]
        public async Task<RespuestaRest<Estudiante?>> EstuddiantePorId(int id)
        {
            var estudiante = await _repositorioDeEstudiantes.ObtenerUnEstudiantePorId(id);
            if (estudiante != null)
            {
                return new RespuestaRest<Estudiante?>()
                {
                    Mensaje = "Succes",
                    Respuesta = estudiante
                };
            }
            else return new RespuestaRest<Estudiante?>() { Mensaje = "No se encontro el estidiante" };

        }

        [HttpPost("Agregar")]
        public async Task<RespuestaRest<bool>> AgregarEstudiante([FromBody] Estudiante estudiante)
        {
            var resultado = await _repositorioDeEstudiantes.RegistrarUnEstudiante(estudiante);
            return new RespuestaRest<bool>()
            {
                Respuesta = true
            };
        }


        [HttpPut("Editar")]
        public async Task<RespuestaRest<bool>> EditarEstudiante([FromBody] Estudiante estudiante)
        {
            var resultado = await _repositorioDeEstudiantes.EditarUnEstudiante(estudiante);
            return new RespuestaRest<bool>()
            {
                Respuesta = true
            };
        }

    
        [HttpDelete("Eliminar")]
        public async Task<RespuestaRest<bool>> EliminarEstudiante(int id)
        {
            var resultado =  await _repositorioDeEstudiantes.EliminarUnEstudiante( id);
            return new RespuestaRest<bool>()
            {
                Respuesta = true
            };
        }

        [HttpGet("Nombre")]
        public async Task<RespuestaRest<List<Estudiante?>>> EstuddiantePorNombre(string nombre)
        {
            var estudiantes = await _repositorioDeEstudiantes.ObtenerEstudiantePorNombre(nombre);
            if (estudiantes != null)
            {
                return new RespuestaRest<List<Estudiante?>>()
                {
                    Mensaje = "Succes",
                    Respuesta = estudiantes
                };
            }
            else return new RespuestaRest<List<Estudiante?>>() { Mensaje = "No se encontro el estidiante" };

        }

        [HttpGet("Cedula")]
        public async Task<RespuestaRest<List<Estudiante?>>> EstuddiantePorCedula(string cedula)
        {
            var estudiantes = await _repositorioDeEstudiantes.ObtenerEstudiantePorCedula(cedula);
            if (estudiantes != null)
            {
                return new RespuestaRest<List<Estudiante?>>()
                {
                    Mensaje = "Succes",
                    Respuesta = estudiantes
                };
            }
            else return new RespuestaRest<List<Estudiante?>>() { Mensaje = "No se encontro el estidiante" };
        }

        [HttpGet("Apellidos")]
        public async Task<RespuestaRest<List<Estudiante?>>> EstuddiantePorApellidos(string apellido)
        {
            var estudiantes = await _repositorioDeEstudiantes.ObtenerEstudiantePorApellidos(apellido);
            if (estudiantes != null)
            {
                return new RespuestaRest<List<Estudiante?>>()
                {
                    Mensaje = "Succes",
                    Respuesta = estudiantes
                };
            }
            else return new RespuestaRest<List<Estudiante?>>() { Mensaje = "No se encontro el estidiante" };
        }


        [HttpGet("Historial")]
        public async Task<RespuestaRest<List<List<Estudiante?>>>> VerHistorialFamiliar(int id)
        {
            var estudiantes = await _repositorioDeEstudiantes.ObtenerHistorialFamiliar(id);
            if (estudiantes != null)
            {
                return new RespuestaRest<List<List<Estudiante?>>>()
                {
                    Mensaje = "Succes",
                    Respuesta = estudiantes
                };
            }
            else return new RespuestaRest<List<List<Estudiante?>>>() { Mensaje = "No se encontro el estidiante" };
        }

    }
}
