﻿
namespace Matricula.AppMovil.Models.Dtos
{

    public class RespuestaRest
    {
        public bool esSucces { get; set; } = true;
        public Object Respuesta { get; set; }
        public string Mensaje { get; set; }


    }

}