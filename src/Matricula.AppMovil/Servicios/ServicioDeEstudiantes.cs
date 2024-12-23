using Matricula.AppMovil.Models;
using Matricula.AppMovil.Models.Dtos;
using Matricula.AppMovil.Servicios.Iservicios;
using Newtonsoft.Json;

namespace Matricula.AppMovil.Servicios
{
    internal class ServicioDeEstudiantes : IServicioDeEstudiantes
    {

        private readonly IServicioRest _serviciorest;
        public ServicioDeEstudiantes()
        {
            _serviciorest = App.Current.Servicios.GetRequiredService<IServicioRest>();
        }


        public async Task<List<Estudiante>> ListaDeEstudiantesRegistrados()
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRest()
            {
                MetodoRest = MetodoREST.GET,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfigurarApi.API_URL + $""
            });
            var estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(Convert.ToString(respuesta.Respuesta));
            return estudiantes;
        }

        public async Task<List<Estudiante>> ObtenerHombresRegistrados()
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRest()
            {
                MetodoRest = MetodoREST.GET,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfigurarApi.API_URL + $"/Hombres"
            });
            return JsonConvert.DeserializeObject<List<Estudiante>>(Convert.ToString(respuesta.Respuesta));
        }

        public async Task<List<Estudiante>> ObtenerMujeresRegistrados()
        {
            var respuesta = await _serviciorest.SendAsync(new ConsultaRest()
            {
                MetodoRest = MetodoREST.GET,
                TipoDeContenido = TipoDeContenido.Json,
                URL = ConfigurarApi.API_URL + $"/Mujeres"
            });
            return JsonConvert.DeserializeObject<List<Estudiante>>(Convert.ToString(respuesta.Respuesta));
        }
    }
}

