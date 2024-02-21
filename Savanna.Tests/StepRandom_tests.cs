using Savanna.GameLogic;
using Savanna.GameLogic.Interfaces;

namespace Savanna.Tests

{
    [TestClass]
    public class StepRandom_tests
    {
        [TestMethod]
        public void GivenBoundries_WhenGetRadomInt_ThenInt4()
        {
            //Arrange
            IRandom random = new StepRandom();

            //Act
            int getRandom = random.GetRandomInt(0, 5);

            //Assert
            Assert.IsTrue(getRandom < 5 && getRandom >= 0);
        }
    }
}
