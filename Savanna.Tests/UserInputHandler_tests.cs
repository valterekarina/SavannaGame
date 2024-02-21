using Moq;
using Savanna.AnimalBehavior;
using Savanna.GameLogic;
using Savanna.GameLogic.Interfaces;

namespace Savanna.Tests
{
    internal class FakeInput : IGetInput
    {
        public string GetInput()
        {
            return "5";
        }
    }
    [TestClass]
    public class UserInputHandler_tests
    {
        private readonly UserInputHandler _handler;
        private readonly Mock<IAnimalBirth> _animalBirthMock;
        private readonly Mock<IConsoleFacade> _consoleFacadeMock;
        public UserInputHandler_tests()
        {
            _consoleFacadeMock = new Mock<IConsoleFacade>();
            _animalBirthMock = new Mock<IAnimalBirth>();
            _handler = new UserInputHandler(_animalBirthMock.Object, _consoleFacadeMock.Object);
        }

        [TestMethod]
        public void GivenFakeInput_WhenChooseFieldHeight_ThenReturnFakeInput()
        {
            //Arrange
            IGetInput getInput = new FakeInput();
            //Act
            int height = _handler.ChooseFieldHeight(getInput);

            //Assert
            Assert.AreEqual(5, height);
        }

        [TestMethod]
        public void GivenFakeInput_WhenChooseFieldWidth_ThenReturnFakeInput()
        {
            //Arrange
            IGetInput getInput = new FakeInput();
            //Act
            int width = _handler.ChooseFieldWidth(getInput);

            //Assert
            Assert.AreEqual(5, width);
        }

        [TestMethod]
        public void GivenPositiveInteger_whenCheckHeight_ThenResultInteger()
        {
            //Arrange
            string heightInput = "5"; ;

            //Act
            int result = _handler.CheckHeight(heightInput);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void GivenNegativeInteger_whenCheckHeight_ThenResultZero()
        {
            //Arrange
            string heightInput = "-1";

            //Act
            int result = _handler.CheckHeight(heightInput);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GivenString_whenCheckHeight_ThenResultZero()
        {
            //Arrange
            string heightInput = "a";

            //Act
            int result = _handler.CheckHeight(heightInput);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GivenPositiveInteger_whenCheckWidth_ThenResultInteger()
        {
            //Arrange
            string widthInput = "5";

            //Act
            int result = _handler.CheckWidth(widthInput);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void GivenZero_whenCheckWidth_ThenResultZero()
        {
            //Arrange
            string widthInput = "0";

            //Act
            int result = _handler.CheckWidth(widthInput);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GivenString_whenCheckWidth_ThenResultZero()
        {
            //Arrange
            string widthInput = "=";

            //Act
            int result = _handler.CheckWidth(widthInput);

            //Assert
            Assert.AreEqual(0, result);
        }
    }
}