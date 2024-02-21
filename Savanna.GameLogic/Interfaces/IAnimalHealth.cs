using Savanna.AnimalBehavior;

namespace Savanna.GameLogic.Interfaces
{
    public interface IAnimalHealth
    {
        void DecreaseHealth(List<IAnimal> animals);
        void ShowHealthMetrics(List<IAnimal> animals);
        void IsAnimalAlive(List<IAnimal> animals);
        public void IncreaseHealth(IAnimal animal);
    }
}