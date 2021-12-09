using Intexus.Comun.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Intexus.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Afiliado afiliado = new Afiliado
            {
                Id = 1,
                Nombre = "Yonathan Armando",
                Apellido = "Rodriguez Rodriguez",
                Sexo = "M",
                FechaNacimiento = new DateTime(1988, 10, 24),
                Recaudo = 1200000
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(afiliado);
            Console.WriteLine($"json {json}");

        }
    }
}
