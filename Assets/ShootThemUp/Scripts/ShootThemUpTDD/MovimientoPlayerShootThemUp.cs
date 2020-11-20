using NSubstitute;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MovimientoPlayerShootThemUp
    {
        IMovimientoPlayerShootMono subMono;
        LogicaDeMovimientoPlayerShoot logica;
        [SetUp]
        public void SetUp()
        {
            subMono = Substitute.For<IMovimientoPlayerShootMono>();
            logica = new LogicaDeMovimientoPlayerShoot(subMono, 0, 0);
        }

        [TearDown]
        public void TearDown()
        {
            subMono = default;
            logica = default;
        }

        [TestCase(1, 1, 1, 1)]
        [TestCase(0, 1, 1, 0)]
        [TestCase(1, 0, 1, 0)]
        [TestCase(1, 1, 0, 0)]
        [TestCase(0, 0, 0, 0)]
        public void MovimientoPlayerShoot_X_CasosExitosos(
            float velocidadMovimiento,
            float movimientoX,
            float delta,
            float esperadoX
            )
        {
            logica.VelocidadDeMovimiento = velocidadMovimiento;
            var resultado = logica.CalculandoMovimientoDelPlayer(movimientoX, Arg.Any<float>(), delta);

            Assert.AreEqual(esperadoX, resultado.x);
        }

        [TestCase(1, 1, 1, 1)]
        [TestCase(0, 1, 1, 0)]
        [TestCase(1, 0, 1, 0)]
        [TestCase(1, 1, 0, 0)]
        [TestCase(0, 0, 0, 0)]
        public void MovimientoPlayerShoot_Y_CasosExitosos(
            float velocidadMovimiento,
            float movimientoY,
            float delta,
            float esperadoY
            )
        {
            logica.VelocidadDeMovimiento = velocidadMovimiento;

            var resultado = logica.CalculandoMovimientoDelPlayer(Arg.Any<float>(), movimientoY, delta);

            Assert.AreEqual(esperadoY, resultado.y);
        }

        [TestCase(1, 1, true)]
        [TestCase(1, 2, false)]
        [TestCase(2, 1, true)]
        public void PuedeDispararElPlayer(int cantidadDeDisparos, int disparoNum, bool esperado)
        {
            logica.CantidadDisparosSimultaneos = cantidadDeDisparos;

            Assert.AreEqual(esperado, logica.PuedeDisparar(disparoNum));
        }
    }
}
