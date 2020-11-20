using NSubstitute;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SpawnerEnemigoTDD
    {
        LogicaDelSpawner logica;
        ISpawnearEnemigos subMono;

        [SetUp]
        public void SetUp()
        {
            subMono = Substitute.For<ISpawnearEnemigos>();
            List<EnemigoGeneral_shoot> lista = new List<EnemigoGeneral_shoot>();
            logica = new LogicaDelSpawner(subMono, 0, lista);
        }
        [TearDown]
        public void TearDown()
        {
            subMono = default;
            logica = default;
        }
        // A Test behaves as an ordinary method
        [TestCase(2, 1, 1)]
        [TestCase(2, 3, 0)]
        public void SpawnerEnemigoTDDSimplePasses(float delta, float tiempo, int esperado)
        {
            logica.TiempoDeSpawn = tiempo;
            logica.EsTiempoDeSpawnear(delta);

            subMono.Received(esperado).SpawnearEnemigo();
        }

        [TestCase(0, "raro")]
        [TestCase(10, "raro")]
        [TestCase(11, "general")]
        [TestCase(25, "general")]
        [TestCase(26, "capitan")]
        [TestCase(50, "capitan")]
        [TestCase(51, "obrero")]
        [TestCase(100, "obrero")]
        public void FactoriaDeEnemigos_CasosExitosos(int pro, string idEsperada)
        {
            //
            subMono.RandomLocal(Arg.Any<int>(), Arg.Any<int>()).Returns(pro);
            List<EnemigoGeneral_shoot> lista = new List<EnemigoGeneral_shoot>()
            {
                new EnemigoRaro()
                {
                    Id = "raro"
                },
                new EnemigoObrero()
                {
                    Id = "obrero"
                },
                new EnemigoGeneralPrimero()
                {
                    Id = "general"
                },
                new EnemigoCapitan()
                {
                    Id = "capitan"
                }
            };
            //Act
            logica.Factoria = new FactoriaEnemigos(lista);

            Assert.AreEqual(idEsperada, logica.InstanciarEnemigo().Id);
        }
    }
}
