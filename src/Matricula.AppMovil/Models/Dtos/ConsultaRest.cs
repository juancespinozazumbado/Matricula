
namespace Matricula.AppMovil.Models.Dtos
{
    public class ConsultaRest
    {
        public string? URL { get; set; }
        public Object Cuerpo { get; set; } = null;
        public MetodoREST MetodoRest { get; set; } = MetodoREST.GET;
        public TipoDeContenido TipoDeContenido { get; set; } = TipoDeContenido.Json;

    }

    public enum MetodoREST
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum TipoDeContenido
    {
        Json
    }


}
