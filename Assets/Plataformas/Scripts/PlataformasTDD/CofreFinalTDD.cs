using NSubstitute;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CofreFinalTDD
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CofreFinal_CuandoElPlayerColisionaConElObjeto()
        {
            // Use the Assert class to test conditions
            IConfreFinalMono mono = Substitute.For<IConfreFinalMono>();
            LogicaCofreFinal logica = new LogicaCofreFinal(mono);

            logica.ElPlayerTocoElCofre(true);

            mono.Received(1).LlamarAnimacionDeApertura();
        }
        
    }
}
