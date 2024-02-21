using Savanna.AnimalBehavior;

namespace Savanna.GameLogic.Interfaces
{
    public interface IAnimalBirth
    {
        void CheckNear(List<IAnimal> animals, List<IAnimal> allAnimals, IField field);
        void BirthAnimal(List<IAnimal> animals, Type animalType, List<IAnimal> specifiedAnimals, IField field);
    }
}