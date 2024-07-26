using Matricula.UI.Models.Dtos;

namespace Matricula.UI.Servicios.Iservicios
{
    public interface IservicioRest
    {

        Task<RespuestaRestDto?> SendAsync(ConsultaRestDto requestDto );
    }
}
