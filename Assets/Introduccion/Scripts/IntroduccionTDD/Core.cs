using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

namespace Tests
{
    public class Core
    {
        [SetUp]
        public void SetUp()
        {
            var sustituto = new ConvertidorDeEnumToInt();
            ServiceLocator.Instance.RegisterService<IConvertidorDeEnumToInt>(sustituto);
        }

        [TearDown]
        public void TearDown()
        {
            ServiceLocator.Instance.ClearAll();
        }
        // A Test behaves as an ordinary method
        [TestCase(EscenasDelJuego.INICIO,0)]
        [TestCase(EscenasDelJuego.NOVELAVISUAL, 1)]
        [TestCase(EscenasDelJuego.PLATAFORMAS, 2)]
        [TestCase(EscenasDelJuego.SHOOTTHEMUP, 3)]
        public void Core_ConvertEnumToInt_trueAssertion(EscenasDelJuego escena, int esperado)
        {
            //act
            var resultado = ServiceLocator.Instance.GetService<IConvertidorDeEnumToInt>().ConvertEnumToInt(escena);

            //Assert
            Assert.AreEqual(esperado, resultado);
        }
    }
}
