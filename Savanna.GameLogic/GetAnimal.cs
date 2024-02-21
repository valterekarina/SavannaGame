using Savanna.AnimalBehavior;
using Savanna.GameLogic.Interfaces;

namespace Savanna.GameLogic
{
    public class GetAnimal : IGetAnimal
    {
        public void GetAnimalByType(List<IAnimal> animals, List<IAnimal> AnimalsCatch, List<IAnimal> AnimalsRun)
        {
            AnimalsCatch.Clear();
            AnimalsRun.Clear();
            foreach (var animal in animals)
            {
                if (animal.RunOrCatch == "Catch")
                {
                    AnimalsCatch.Add(animal);
                }
                else if (animal.RunOrCatch == "Run")
                {
                    AnimalsRun.Add(animal);
                }
            }
        }
    }
}
