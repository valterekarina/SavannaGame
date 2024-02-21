using Savanna.AnimalBehavior;
using Savanna.GameLogic.Interfaces;

namespace Savanna.GameLogic
{
    public class AnimalHealth : IAnimalHealth
    {
        private readonly IConsoleFacade _consoleFacade;

        public AnimalHealth(IConsoleFacade consoleFacade)
        {
            _consoleFacade = consoleFacade;
        }
        public void ShowHealthMetrics(List<IAnimal> animals)
        {
            foreach (var animal in animals)
            {
                if (animal.IsAlive)
                {
                    _consoleFacade.WriteLine(animal.Symbol.ToString() + ": " + animal.Health);
                }
            }
        }

        public void DecreaseHealth(List<IAnimal> animals)
        {
            foreach (var animal in animals)
            {
                if (animal.IsAlive)
                {
                    animal.Health = animal.Health - 0.5;
                }
            }
        }

        public void IsAnimalAlive(List<IAnimal> animals)
        {
            foreach (var animal in animals)
            {
                if (animal.Health == 0)
                {
                    animal.IsAlive = false;
                }
            }
        }

        public void IncreaseHealth(IAnimal animal)
        {
            if (animal.Health <= 50)
            {
                animal.Health += 50.5;
            }
            else
            {
                animal.Health = 100.5;
            }
        }
    }
}
