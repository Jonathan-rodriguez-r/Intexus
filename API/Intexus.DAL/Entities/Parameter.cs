using System;
using System.Collections.Generic;
using System.Text;

namespace Intexus.DAL.Entities
{
    public class Parameter
    {

        public string Nombre { get; set; }

        public int Tamano { get; set; }

        public TipoDato TipoDato { get; set; }

        public String ValorEnviar { get; set; }

        public Byte[] Byte { get; set; }
    }

    public enum TipoDato : int
    {
        Integer = 1,
        Varchar = 2,
        Date = 3,
        Boolean = 4,
        Imagen = 5,
        Double = 6,
        Long = 7,
        Xml = 8,
        Text = 9,
        JSON = 10,
        Char = 11,
        Decimal =12
    }
}
