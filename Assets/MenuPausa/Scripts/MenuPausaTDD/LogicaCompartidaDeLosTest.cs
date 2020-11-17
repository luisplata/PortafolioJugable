using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    public class LogicaCompartidaDeLosTest
    {
        protected ILogicaDeMenuDePausa logica;
        protected LogicaDelMenuDePausa logicaCreada;
        [SetUp]
        public void SetUp()
        {
            logica = Substitute.For<ILogicaDeMenuDePausa>();
            logicaCreada = new LogicaDelMenuDePausa(logica);
        }

        [TearDown]
        public void TearDown()
        {
            logica = default;
            logicaCreada = default;
        }

    }
}
