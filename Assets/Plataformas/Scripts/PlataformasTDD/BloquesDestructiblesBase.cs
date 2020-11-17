using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

namespace Tests
{
    public class BloquesDestructiblesBase
    {
        BloqueDestructibleGenerico subtitutoDelMono;
        LogicaDeBloquesDestructibles logica;
        [SetUp]
        public void SetUp()
        {
            subtitutoDelMono = Substitute.For<BloqueDestructibleGenerico>();
            logica = new LogicaDeBloquesDestructibles(subtitutoDelMono);
        }

        [TearDown]
        public void TearDown()
        {
            subtitutoDelMono = default;
            logica = default;
        }

        // A Test behaves as an ordinary method
        [TestCase(true, 1)]
        [TestCase(false, 0)]
        public void RomperElBloque_CuandoEsConLaCabeza_DebeSerRoto(bool esLaCabeza, int cuantasVecesFueLLamadoElMetodo)
        {
            //act
            logica.CuandoElPlayerNosPegaConLaCabeza(esLaCabeza);

            //Assert
            subtitutoDelMono.Received(cuantasVecesFueLLamadoElMetodo).CuandoLePeganAlBloque();
        }
    }
}
