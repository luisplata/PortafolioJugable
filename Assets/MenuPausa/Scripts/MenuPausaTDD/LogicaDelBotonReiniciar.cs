using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

namespace Tests
{
    public class LogicaDelBotonReiniciar : LogicaCompartidaDeLosTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void AccionBotonReinicarNivel_SinTerminarLaAnimacion_ReiniciarDebeEstarEnFalse()
        {
            //hacer
            logicaCreada.TerminoLaAnimacion = false;
            logicaCreada.AccionBotonReinicarNivel();

            //assert
            Assert.IsFalse(logicaCreada.ReiniciarNivel);
        }

        [Test]
        public void AccionDeReiniciarNivel_ConAnimacionTerinada_ReiniciarNivelDebeSerTrue()
        {
            //Hacer
            logicaCreada.AccionBotonReinicarNivel();
            //assert
            Assert.IsTrue(logicaCreada.ReiniciarNivel);
        }

        [Test]
        public void AccionDeReiniciarNivel_ConAnimacionTerinada_DebeEjecutarLaFuncion()
        {
            logicaCreada.AccionBotonReinicarNivel();

            logica.Received().Ending();
        }

        [Test]
        public void AccionDeReiniciarNivel_ConAnimacionTerinada_NoDebeEjecutarLaFuncion()
        {
            logicaCreada.TerminoLaAnimacion = false;
            logicaCreada.AccionBotonReinicarNivel();

            logica.Received(0).Ending();
        }
    }
}
