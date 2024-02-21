using Savanna.AnimalBehavior;
using Savanna.GameLogic;
using Savanna.GameLogic.Interfaces;
using Moq;

namespace Savanna.Tests
{
    [TestClass]
    public class GetAnimal_tests
    {
        private readonly IGetAnimal _getAnimal;
        private readonly IField _field;
        private readonly Mock<IConsoleFacade> _consoleFacade;
        public GetAnimal_tests()
        {
            _consoleFacade = new Mock<IConsoleFacade>();
            _getAnimal = new GetAnimal();
            _field = new Field(5, 5, _consoleFacade.Object);
        }

        [TestMethod]
        public void Given2Animals_WhenGetLion_ThenLionCount1()
        {
            //Arrange
            var animalsCatch = new List<IAnimal>();
            var animalsRun = new List<IAnimal>();
            var animals = new List<IAnimal>()
            {
                new Lion { IsAlive = true, X = _field.Height-1, Y = 0 },
                new Antelope { IsAlive = true, X = 0, Y = 0 }
            };

            //Act
            _getAnimal.GetAnimalByType(animals, animalsCatch, animalsRun);

            //Assert
            Assert.AreEqual(1, animalsCatch.Count);
        }

        [TestMethod]
        public void Given3Animals_WhenGetAntelope_ThenAntelopeCount2()
        {
            //Arrange
            var animalsCatch = new List<IAnimal>();
            var animalsRun = new List<IAnimal>();
            List<IAnimal> animals = new()
            {
                new Lion { IsAlive = true, X = _field.Height-1, Y = 0 },
                new Antelope { IsAlive = true, X = 0, Y = 0 },
                new Antelope{ IsAlive = true, X = 2, Y = 2 }
            };

            //Act
            _getAnimal.GetAnimalByType(animals, animalsCatch, animalsRun);

            //Assert
            Assert.AreEqual(2, animalsRun.Count);
        }
    }
}
