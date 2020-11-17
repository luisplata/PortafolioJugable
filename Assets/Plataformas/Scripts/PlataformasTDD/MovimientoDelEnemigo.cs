using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

namespace Tests
{
    public class MovimientoDelEnemigo
    {
        LogicaPlataformaDeMovimientoEnemigo logica;
        ILogicaDeMovimientoDelEnemigo monoSubstituto;
        [SetUp]
        public void SetUp()
        {
            monoSubstituto = Substitute.For<ILogicaDeMovimientoDelEnemigo>();
            logica = new LogicaPlataformaDeMovimientoEnemigo(default, monoSubstituto);
        }

        [TearDown]
        public void TearDown()
        {
            logica = default;
            monoSubstituto = default;
        }

        [Test]
        public void CalcularDireccion_CuandoNoDebeMoverse_DebeRetornarCeroEnX()
        {
            //assert
            Assert.AreEqual(0, logica.CalcularDireccionDeMovimientoDelEnemigo().x);
        }

        [Test]
        public void CalcularDireccion_CuandoDebeMoverse_DebeRetornaAlgoEnX()
        {
            logica.Start = true;
            logica.Speed = 1;
            //assert
            Assert.AreNotEqual(0, logica.CalcularDireccionDeMovimientoDelEnemigo().x);
        }

        [TestCase(true,1)]
        [TestCase(false, -1)]
        public void CalcularDireccion_CuandoDebeMoverse_DebeRetornaAlgoEnX(bool debeFlipear, float movimientoEnX)
        {
            logica.Start = true;
            logica.Speed = 1;
            logica.Flip = debeFlipear;
            //assert
            Assert.AreEqual(movimientoEnX, logica.CalcularDireccionDeMovimientoDelEnemigo().x);
        }

        [TestCase(true, false, true, false)]
        [TestCase(false, true, true, false)]
        [TestCase(true, true, true, false)]
        [TestCase(false, false, true, true)]
        public void CambioDeDireccion_CuandoColisiona_CasosExitosos(bool esObstaculo, 
            bool esEnemigo, 
            bool valorDeFlip, 
            bool esperado)
        {
            //act
            logica.Flip = valorDeFlip;
            logica.DebeCambiarDeLadoCuandoColisione(esObstaculo, esEnemigo);

            //assert
            Assert.AreEqual(esperado, logica.Flip);
        }

        [TestCase(false, true, true)]
        [TestCase(true, true, false)]
        public void ColisionDeMuerte_CuandoElPlayerGolpea_DebequitarElStart(bool esElPie, bool startini, bool startEnd)
        {
            //act
            var subs = Substitute.For<IMovimientoPlayerPlataformas>();
            logica.Start = startini;
            logica.ColisionoConLaParteQueMataDelPlayer(esElPie, subs);

            //assert
            Assert.AreEqual(startEnd, logica.Start);
        }
    }
}
