using Savanna.AnimalBehavior;

namespace Savanna.GameLogic.Interfaces
{
    public interface IGetAnimal
    {
        void GetAnimalByType(List<IAnimal> animals, List<IAnimal> animalsCatch, List<IAnimal> animalsRun);
    }
}
