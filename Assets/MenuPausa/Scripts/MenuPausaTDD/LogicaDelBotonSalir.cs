using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LogicaDelBotonSalir : LogicaCompartidaDeLosTest
    {

        // A Test behaves as an ordinary method
        [Test]
        public void BotonSalir_AnimacionSinTerminar_NoDebeSalir()
        {
            //act
            logicaCreada.TerminoLaAnimacion = false;
            logicaCreada.AccionBotonSalir();

            //assert
            Assert.IsFalse(logicaCreada.VolverAlInicio);
        }

        [Test]
        public void BotonSalir_AnimacionSinTerminar_DebeSalir()
        {
            //act
            logicaCreada.AccionBotonSalir();

            //assert
            Assert.IsTrue(logicaCreada.VolverAlInicio);
        }

        [Test]
        public void AccionDeSalirNivel_ConAnimacionTerinada_NoDebeEjecutarLaFuncion()
        {
            logicaCreada.TerminoLaAnimacion = false;
            logicaCreada.AccionBotonSalir();

            logica.Received(0).Ending();
        }

        [Test]
        public void AccionDeSalirNivel_ConAnimacionTerinada_DebeEjecutarLaFuncion()
        {
            logicaCreada.AccionBotonSalir();

            logica.Received().Ending();
        }
    }
}
