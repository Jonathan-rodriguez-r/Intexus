using Intexus.Comun.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intexus.Comun.Api
{
    public class ApiResponse
    {
        public ApiStatus Respuesta { get; set; }
        public string Mensaje { get; set; }
        public List<Afiliado> ResponseParams { get; set; }
    }

    public enum ApiStatus
    {
        OK = 1,
        Error = 2,
        Otro = 3
    }
}
