using NSubstitute;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EnemigoGenericoTDD
    {
        // A Test behaves as an ordinary method
        [TestCase(2, 1, 0)]
        [TestCase(2, 2, 1)]
        [TestCase(2, 3, 1)]
        public void RestarVidaEnElEnemigo(int vida, int danio, int esperado)
        {
            IEnemigoGenericoMono mono = Substitute.For<IEnemigoGenericoMono>();
            IControlDorDeUiShotThemUp ui = Substitute.For<IControlDorDeUiShotThemUp>();
            LogicaDeEnemigoGenerico logica = new LogicaDeEnemigoGenerico(mono, ui, 0, 0, 0);

            //act
            IBalaPlayerShoot bala = Substitute.For<IBalaPlayerShoot>();
            bala.GetPoderDeBala().Returns(danio);
            logica.Vida = vida;
            logica.RestandoVidaAlEnemigoPorLaBalaQueLlega(bala);

            //assert
            mono.Received(esperado).EsteEnemigoMuere();
        }
    }
}
