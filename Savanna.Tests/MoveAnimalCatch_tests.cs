using Moq;
using Savanna.AnimalBehavior;
using Savanna.GameLogic;
using Savanna.GameLogic.Interfaces;

namespace Savanna.Tests
{
    [TestClass]
    public class MoveAnimalCatch_tests
    {
        private readonly Mock<IRandom> _randomMock;
        private readonly Mock<IField> _fieldMock;
        private readonly IMoveAnimalCatch _moveAnimalCatch;
        private readonly Mock<IAnimalHealth> _animalHealthMock;
        private readonly Mock<IConsoleFacade> _consoleFacadeMock;
        private readonly IConstants _constants;
        public MoveAnimalCatch_tests()
        {
            _constants = new Constants();
            _consoleFacadeMock = new Mock<IConsoleFacade>();
            _fieldMock = new Mock<IField>();
            _fieldMock.Setup(f => f.Height).Returns(10);
            _fieldMock.Setup(f => f.Width).Returns(10);
            _fieldMock.Setup(f => f.InitializedField).Returns(new char[10, 10]);
            _randomMock = new Mock<IRandom>();
            _randomMock.Setup(r => r.GetRandomInt(-2, 3)).Returns(1);
            _moveAnimalCatch = new MoveAnimalCatch(_randomMock.Object, _consoleFacadeMock.Object, _constants);
            _animalHealthMock = new Mock<IAnimalHealth>();
        }

        [TestMethod]
        public void GivenLionMax0_WhenMoveLion_ThenCoordinates()
        {
            //Arrange
            List<IAnimal> animals = new()
            {
                new Lion { IsAlive = true, X = _fieldMock.Object.Height-1, Y = 0 }
            };

            //Act
            _moveAnimalCatch.AnimalCatchMove(animals, _fieldMock.Object, _animalHealthMock.Object);

            //Assert


            Assert.AreEqual(_fieldMock.Object.Height - 3, animals[0].X);
            Assert.AreEqual(2, animals[0].Y);

        }

        [TestMethod]
        public void Given2Lions_WhenMoveLion_ThenDontMove()
        {
            //Arrange
            List<IAnimal> animals = new()
            {
                new Lion { IsAlive = true, X = 0, Y = 0 },
                new Lion { IsAlive = true, X = 2, Y = 2 }
            };

            //Act
            _moveAnimalCatch.AnimalCatchMove(animals, _fieldMock.Object, _animalHealthMock.Object);

            //Assert
            Assert.AreEqual(0, animals[0].X);
            Assert.AreEqual(0, animals[0].Y);
        }

        [TestMethod]
        public void GivenLion0Max_WhenMoveLion_ThenCoordinates()
        {
            //Arrange
            List<IAnimal> animals = new()
            {
                new Lion { IsAlive = true, X = 0, Y = _fieldMock.Object.Width-1 }
            };


            //Act
            _moveAnimalCatch.AnimalCatchMove(animals, _fieldMock.Object, _animalHealthMock.Object);

            //Assert
            Assert.AreEqual(2, animals[0].X);
            Assert.AreEqual(_fieldMock.Object.Width - 3, animals[0].Y);
        }

        [TestMethod]
        public void GivenLionInThrMiddle_WhenMoveLion_ThenCoordinates()
        {
            //Arrange
            List<IAnimal> animals = new()
            {
                new Lion { IsAlive = true, X = 3, Y = 3 }
            };

            //Act
            _moveAnimalCatch.AnimalCatchMove(animals, _fieldMock.Object, _animalHealthMock.Object);

            //Assert


            Assert.AreEqual(4, animals[0].X);
            Assert.AreEqual(4, animals[0].Y);

        }

        [TestMethod]
        public void GivenLionAndAntelope_WhenMoveLion_ThenCheckAnimalsAndCatchAnimal()
        {
            //Arrange
            List<IAnimal> animals = new()
            {
                new Lion { IsAlive = true, X = 2, Y = 2 },
                new Antelope { IsAlive = true, X = 3, Y = 3 }
            };

            //Act
            _moveAnimalCatch.AnimalCatchMove(animals, _fieldMock.Object, _animalHealthMock.Object);

            //Assert
            Assert.AreEqual(3, animals[0].X);
            Assert.AreEqual(3, animals[0].Y);
        }

        [TestMethod]
        public void GivenLionAndAntelopefurther_WhenMoveLion_ThenCheckAnimalsAndCatchAnimal()
        {
            //Arrange
            List<IAnimal> animals = new()
            {
                new Lion { IsAlive = true, X = 2, Y = 2 },
                new Antelope { IsAlive = true, X = 0, Y = 0 }
            };

            //Act
            _moveAnimalCatch.AnimalCatchMove(animals, _fieldMock.Object, _animalHealthMock.Object);

            //Assert
            Assert.AreEqual(0, animals[0].X);
            Assert.AreEqual(0, animals[0].Y);
        }
    }
}
