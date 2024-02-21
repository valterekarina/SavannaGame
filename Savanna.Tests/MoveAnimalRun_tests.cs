using Moq;
using Savanna.AnimalBehavior;
using Savanna.GameLogic;
using Savanna.GameLogic.Interfaces;

namespace Savanna.Tests
{
    [TestClass]
    public class MoveAnimalRun_tests
    {
        private readonly Mock<IRandom> _randomMock;
        private readonly Mock<IField> _fieldMock;
        private readonly MoveAnimalRun _moveAnimalRun;
        private readonly IConstants _constants;

        public MoveAnimalRun_tests()
        {
            _constants = new Constants();
            _fieldMock = new Mock<IField>();
            _fieldMock.Setup(f => f.Height).Returns(10);
            _fieldMock.Setup(f => f.Width).Returns(10);
            _fieldMock.Setup(f => f.InitializedField).Returns(new char[10, 10]);
            _randomMock = new Mock<IRandom>();
            _randomMock.Setup(r => r.GetRandomInt(-1, 2)).Returns(1);
            _moveAnimalRun = new MoveAnimalRun(_randomMock.Object, _constants);
        }

        [TestMethod]
        public void GivenAntelope00_WhenMoveAntelope_ThenCoordinates()
        {
            //Arrange
            List<IAnimal> animals = new()
            {
                new Antelope { IsAlive = true, X = 0, Y = 0 }
            };

            //Act
            _moveAnimalRun.AnimalRunMove(animals, _fieldMock.Object);

            //Assert
            Assert.AreEqual(1, animals[0].X);
            Assert.AreEqual(1, animals[0].Y);
        }

        [TestMethod]
        public void Given2Antelopes_WhenMoveAntelope_ThenDontMove()
        {
            //Arrange
            List<IAnimal> animals = new()
            {
                new Antelope { IsAlive = true, X = 0, Y = 0 },
                new Antelope { IsAlive = true, X = 1, Y = 1 }
            };

            //Act
            _moveAnimalRun.AnimalRunMove(animals, _fieldMock.Object);

            //Assert
            Assert.AreEqual(0, animals[0].X);
            Assert.AreEqual(0, animals[0].Y);
        }

        [TestMethod]
        public void GivenAntelopeMaxMax_WhenMoveAntelope_ThenCoordinates()
        {
            //Arrange
            List<IAnimal> animals = new()
            {
                new Antelope { IsAlive = true, X = _fieldMock.Object.Height-1, Y = _fieldMock.Object.Width-1 }
            };


            //Act
            _moveAnimalRun.AnimalRunMove(animals, _fieldMock.Object);

            //Assert
            Assert.AreEqual(_fieldMock.Object.Height - 2, animals[0].X);
            Assert.AreEqual(_fieldMock.Object.Width - 2, animals[0].Y);
        }

        [TestMethod]
        public void GivenAntelopeInTheMiddle_WhenMoveAntelope_ThenCoordinates()
        {
            //Arrange
            List<IAnimal> animals = new()
            {
                new Antelope { IsAlive = true, X = 5, Y = 5 }
            };

            //Act
            _moveAnimalRun.AnimalRunMove(animals, _fieldMock.Object);

            //Assert
            Assert.AreEqual(6, animals[0].X);
            Assert.AreEqual(6, animals[0].Y);

        }

        [TestMethod]
        public void GivenAntelopeAndLionBiggerCoordinates_WhenMoveAntelope_ThenReturnTrue()
        {
            //Arrange
            List<IAnimal> animals = new()
            {
                new Antelope { IsAlive = true, X = 5, Y = 5 },
                new Lion { IsAlive = true, X = 6, Y = 6 }
            };

            //Act
            _moveAnimalRun.AnimalRunMove(animals, _fieldMock.Object);

            //Assert
            Assert.AreEqual(4, animals[0].X);
            Assert.AreEqual(4, animals[0].Y);
        }

        [TestMethod]
        public void GivenAntelopeAndLionSmallerCoordinates_WhenMoveAntelope_ThenReturnTrue()
        {
            //Arrange
            List<IAnimal> animals = new()
            {
                new Antelope { IsAlive = true, X = 5, Y = 5 },
                new Lion { IsAlive = true, X = 4, Y = 4 }
            };

            //Act
            _moveAnimalRun.AnimalRunMove(animals, _fieldMock.Object);

            //Assert
            Assert.AreEqual(6, animals[0].X);
            Assert.AreEqual(6, animals[0].Y);
        }
    }
}
