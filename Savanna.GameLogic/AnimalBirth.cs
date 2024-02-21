using Savanna.AnimalBehavior;
using Savanna.GameLogic.Interfaces;

namespace Savanna.GameLogic
{
    public class AnimalBirth : IAnimalBirth
    {
        private readonly IRandom _random;
        public AnimalBirth(IRandom random)
        {
            _random = random;
        }

        public void CheckNear(List<IAnimal> animals, List<IAnimal> allAnimals, IField field)
        {
            int count = animals.Count;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    for (int x = -1; x < 2; x++)
                    {
                        for (int y = -1; y < 2; y++)
                        {
                            bool doesBirth = CheckNearTime(animals[i], animals[j], x, y);
                            if (doesBirth)
                            {
                                BirthAnimal(allAnimals, animals[i].GetType(), animals, field);
                            }
                        }
                    }
                }
            }
        }

        private bool CheckNearTime(IAnimal animal, IAnimal otherAnimal, int x, int y)
        {
            if (!animal.Equals(otherAnimal) && animal.X - x == otherAnimal.X && animal.Y - y == otherAnimal.Y
                && otherAnimal.IsAlive && animal.GetType() == otherAnimal.GetType())
            {
                animal.IsNearTime++;
                if (animal.IsNearTime == 3)
                {
                    animal.IsNearTime = 0;
                    otherAnimal.IsNearTime = 0;
                    return true;
                }
            }
            return false;
        }

        public void BirthAnimal(List<IAnimal> animals, Type animalType, List<IAnimal> specifiedAnimals, IField field)
        {
            int count = HowManyAlive(animals);
            if (count < field.Height * field.Width)
            {
                var animal = (IAnimal)Activator.CreateInstance(animalType);
                animal.IsAlive = true;
                animal.X = _random.GetRandomInt(0, field.Height);
                animal.Y = _random.GetRandomInt(0, field.Width);
                animal.Health = 100;
                animal.IsNearTime = 0;

                specifiedAnimals.Add(animal);
                animals.Add(animal);
            }
        }

        private int HowManyAlive(List<IAnimal> animals)
        {
            int count = 0;
            foreach (var animal in animals)
            {
                if (animal.IsAlive)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
