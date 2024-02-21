using Moq;
using Savanna.AnimalBehavior;
using Savanna.GameLogic;
using Savanna.GameLogic.Interfaces;

namespace Savanna.Tests
{
    [TestClass]
    public class AnimalHealth_tests
    {
        private readonly IAnimalHealth _animalHealth;
        private readonly List<IAnimal> _animals;
        private readonly Mock<IConsoleFacade> _consoleFacade;

        public AnimalHealth_tests()
        {
            _consoleFacade = new Mock<IConsoleFacade>();
            _animalHealth = new AnimalHealth(_consoleFacade.Object);
            _animals = new List<IAnimal>(){
                new Lion { IsAlive = true, X = 5, Y = 0, Health = 90, IsNearTime = 0 },
                new Antelope { IsAlive = true, X = 0, Y = 0, Health = 40, IsNearTime = 0 }
            };
        }

        [TestMethod]
        public void GivenAnimalList_WhenDecreaseHealth_ThenHealthDecreased()
        {

            //Act
            _animalHealth.DecreaseHealth(_animals);

            //Assert
            Assert.AreEqual(89.5, _animals[0].Health);
            Assert.AreEqual(39.5, _animals[1].Health);
        }

        [TestMethod]
        public void GivenAnimalList_WhenIsAnimalAlive_ThenTrueorFalse()
        {
            //Arrange
            _animals[0].Health = 0;

            //Act
            _animalHealth.IsAnimalAlive(_animals);

            //Assert
            Assert.IsFalse(_animals[0].IsAlive);
            Assert.IsTrue(_animals[1].IsAlive);
        }

        [TestMethod]
        public void GivenAnimalHealthUnder50_WhenIncreaseHealth_ThenIncreaseBy50()
        {
            //Act
            _animalHealth.IncreaseHealth(_animals[1]);

            //Assert
            Assert.AreEqual(90.5, _animals[1].Health);
        }

        [TestMethod]
        public void GivenAnimalHealthOver50_WhenIncreaseHealth_ThenHealth100()
        {
            //Act
            _animalHealth.IncreaseHealth(_animals[0]);

            //Assert
            Assert.AreEqual(100.5, _animals[0].Health);
        }
    }
}
