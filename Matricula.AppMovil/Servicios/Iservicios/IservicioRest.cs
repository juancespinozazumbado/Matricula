
using Matricula.AppMovil.Models.Dtos;

namespace Matricula.AppMovil.Servicios.Iservicios
{
    public interface IServicioRest
    {
        public Task<RespuestaRest> SendAsync(ConsultaRest requestDto);
    }


}
