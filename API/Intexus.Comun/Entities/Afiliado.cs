using System;
using System.Collections.Generic;
using System.Text;

namespace Intexus.Comun.Entities
{
  public  class Afiliado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Recaudo { get; set; }
    }
}
