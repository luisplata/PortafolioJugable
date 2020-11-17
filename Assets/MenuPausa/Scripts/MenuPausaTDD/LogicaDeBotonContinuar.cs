using NSubstitute;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LogicaDeBotonContinuar:LogicaCompartidaDeLosTest
    {
        [Test]
        public void BotonContinuar_AnimacionSinTerminar_NoDebeContinuar()
        {
            //act
            logicaCreada.TerminoLaAnimacion = false;
            logicaCreada.AccionBotonContinuar();

            //assert
            logica.Received(0).Ending();
        }

        [Test]
        public void BotonContinuar_AnimacionSinTerminar_DebeContinuar()
        {
            //act
            logicaCreada.AccionBotonContinuar();

            //assert
            logica.Received().Ending();
        }

    }
}
