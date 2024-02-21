using Savanna.AnimalBehavior;
using Savanna.GameLogic;
using Savanna.GameLogic.Interfaces;

namespace Savanna.Tests
{
    [TestClass]
    public class Field_tests
    {
        [TestMethod]
        public void GivenList_WhenDisplayField_ThenAnimalsInField()
        {
            //Arrange
            IConsoleFacade consoleFacade = new ConsoleFacade();
            IField field = new Field(5, 5, consoleFacade);
            var animals = new List<IAnimal>()
            {
                new Lion { IsAlive = true, X = field.Height-1, Y = 0, Health = 100, IsNearTime = 0 },
                new Antelope { IsAlive = true, X = 0, Y = 0, Health = 100, IsNearTime = 0  }
            };

            //Act
            field.DisplayField(animals);

            //Asstert
            Assert.AreEqual('A', field.InitializedField[0, 0]);
            Assert.AreEqual('L', field.InitializedField[field.Height - 1, 0]);
        }
    }
}
