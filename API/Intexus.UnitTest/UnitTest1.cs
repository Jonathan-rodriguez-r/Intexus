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
                Sexo = "F",
                FechaNacimiento = new DateTime(1987, 11, 11),
                Recaudo = 1200000
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(afiliado);
            Console.WriteLine($"json {json}");

        }
    }
}
