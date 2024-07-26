namespace Matricula.SI.Modelos.Dtos
{
    public class RespuestaRest<Entidad> 
    {
        public string Mensaje { get; set; } 
        public Entidad Respuesta { get; set; }  
        public string Error { get; set; }   
    }
}
