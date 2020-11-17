using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

namespace Tests
{
    public class MovimientoDelPlayer
    {
        LogicaDeMovimientoPlayer logica;
        IMovimientoPlayerPlataformas subtitutoDelMono;
        [SetUp]
        public void SetUp()
        {
            subtitutoDelMono = Substitute.For<IMovimientoPlayerPlataformas>();
            logica = new LogicaDeMovimientoPlayer(subtitutoDelMono, default);
        }

        [TearDown]
        public void TearDown()
        {
            subtitutoDelMono = default;
            logica = default;
        }

        // A Test behaves as an ordinary method
        [Test]
        public void Flipear_EstandoQuiero_NoDebeFlipear()
        {
            //act
            logica.DebeFlipearElSpriteDelPersonaje(0);

            //asert
            subtitutoDelMono.Received(0).FlipearElEjeX(Arg.Any<bool>());

        }

        [TestCase(-1)]
        [TestCase(1)]
        public void Flipear_EstandoEnMovimiento_DebeFlipear(float movimiento)
        {
            //act
            logica.DebeFlipearElSpriteDelPersonaje(movimiento);

            //asert
            subtitutoDelMono.Received(1).FlipearElEjeX(Arg.Any<bool>());
        }

        [Test]
        public void Flipear_MovimientoHaciaLaDerecha_DebeFlipear()
        {
            //act
            logica.DebeFlipearElSpriteDelPersonaje(1);

            //asert
            subtitutoDelMono.Received(1).FlipearElEjeX(false);

        }

        [Test]
        public void Flipear_MovimientoHaciaLaIzquierda_DebeFlipear()
        {
            //act
            logica.DebeFlipearElSpriteDelPersonaje(-1);

            //asert
            subtitutoDelMono.Received(1).FlipearElEjeX(true);

        }

        [TestCase(0, 0, 0, new float[] { 0, 0 })]
        [TestCase(1, 1, 1, new float[] { 1, 1 })]
        [TestCase(1, 0, 1, new float[] { 1, 0 })]
        [TestCase(0, 1, 1, new float[] { 0, 1 })]
        public void CalculoDeVelocidad_ConMultiplesCasosVelocidad1_TodoDebeSalirBien(float x, 
            float y, 
            float delta,
            float[] resultado)
        {
            //act
            logica.VelocidadMovimiento = 1;

            //asert
            Assert.AreEqual(new Vector2(resultado[0], resultado[1]), logica.CalcularVelocidadDelRigiBody(x, y, delta));

        }

        [TestCase(true, false, true)]
        [TestCase(false, false, false)]
        [TestCase(false, true, true)]
        [TestCase(true, true, true)]
        public void Saltar_CuandoNoASaltado_DebeSaltar(bool presionarParaSaltar, bool yaSalto, bool resultado)
        {
            //act
            logica.Salto = yaSalto;
            logica.Saltar(presionarParaSaltar);

            //asert
            Assert.AreEqual(resultado, logica.Salto);
        }
    }
}
