using Matricula.Model.Entidades;
using Matricula.UI.Models;
using Matricula.UI.Models.Dtos;
using Matricula.UI.Servicios.Iservicios;
using Newtonsoft.Json;

namespace Matricula.UI.Servicios
{
    public class ServicioDeEstudiantes : IservicioDeEstudiantes
    {

        private readonly IservicioRest _serviciorest;
        public ServicioDeEstudiantes(IservicioRest serviciorest)
        {
            _serviciorest = serviciorest;   
        }
        public async Task<bool> EditarUnEstudiante(Estudiante estudiante)
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRestDto()
            {
                MetodoRest = MetodoREST.PUT,
                TipoDeContenido = TipoDeContenido.Json,
                Cuerpo = estudiante,
                URL = ConfiguracionApi.API_URL +$"/Editar"
            });
            return respuesta.esSucces;
        }

        public async Task<bool> EliminarUnEstudiante(int id)
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRestDto()
            {
                MetodoRest = MetodoREST.DELETE,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfiguracionApi.API_URL + $"/Eliminar?id={id}"
            });
            return respuesta.esSucces;
        }

        public async Task<List<Estudiante>> ListaDeEstudiantesRegistrados()
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRestDto()
            {
                MetodoRest = MetodoREST.GET,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfiguracionApi.API_URL + $""
            });
            var estudiantes =  JsonConvert.DeserializeObject<List<Estudiante>>( Convert.ToString(respuesta.Respuesta ));
            return estudiantes;
        }

        public async Task<List<Estudiante>> ObtenerEstudiantePorApellidos(string apellidos)
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRestDto()
            {
                MetodoRest = MetodoREST.GET,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfiguracionApi.API_URL + $"/Apellidos?apellido={apellidos}"
            });
            return JsonConvert.DeserializeObject<List<Estudiante>>(Convert.ToString(respuesta.Respuesta));
        }

        public async Task<List<Estudiante>> ObtenerEstudiantePorCedula(string cedula)
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRestDto()
            {
                MetodoRest = MetodoREST.GET,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfiguracionApi.API_URL + $"/Cedula?cedula={cedula}"
            });
            return JsonConvert.DeserializeObject<List<Estudiante>>(Convert.ToString(respuesta.Respuesta));
        }

        public async Task<List<Estudiante>> ObtenerEstudiantePorNombre(string nombre)
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRestDto()
            {
                MetodoRest = MetodoREST.GET,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfiguracionApi.API_URL + $"/Nombre?nombre={nombre}"
            });
            return JsonConvert.DeserializeObject<List<Estudiante>>(Convert.ToString(respuesta.Respuesta));
        }

        public async Task<List<List<Estudiante>>> ObtenerHistorialFamiliar(int id)
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRestDto()
            {
                MetodoRest = MetodoREST.GET,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfiguracionApi.API_URL + $"/Historial?id={id}"
            });
            return JsonConvert.DeserializeObject<List<List<Estudiante>>>(Convert.ToString(respuesta.Respuesta));
        }

        public async Task<List<Estudiante>> ObtenerHombresRegistrados()
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRestDto()
            {
                MetodoRest = MetodoREST.GET,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfiguracionApi.API_URL + $"/Hombres"
            });
            return JsonConvert.DeserializeObject<List<Estudiante>>(Convert.ToString(respuesta.Respuesta));
        }

        public async Task<List<Estudiante>> ObtenerMujeresRegistrados()
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRestDto()
            {
                MetodoRest = MetodoREST.GET,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfiguracionApi.API_URL + $"/Mujeres"
            });
            return JsonConvert.DeserializeObject<List<Estudiante>>(Convert.ToString(respuesta.Respuesta));
        }

        public async Task<Estudiante> ObtenerUnEstudiantePorId(int id)
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRestDto()
            {
                MetodoRest = MetodoREST.GET,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfiguracionApi.API_URL + $"/Ver?id={id}"
            });
            return JsonConvert.DeserializeObject<Estudiante>(Convert.ToString(respuesta.Respuesta));
        }

        public async Task<bool> RegistrarUnEstudiante(Estudiante estudiante)
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRestDto()
            {
                MetodoRest = MetodoREST.POST,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfiguracionApi.API_URL + $"/Agregar",
                Cuerpo = estudiante
            });
            return respuesta.esSucces;
        }
    }
}
