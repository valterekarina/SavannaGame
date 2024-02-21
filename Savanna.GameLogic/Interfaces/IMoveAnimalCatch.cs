using Savanna.AnimalBehavior;

namespace Savanna.GameLogic.Interfaces
{
    public interface IMoveAnimalCatch
    {
        void AnimalCatchMove(List<IAnimal> animals, IField Field, IAnimalHealth animalHealth);
    }
}
