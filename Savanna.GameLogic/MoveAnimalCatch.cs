using Savanna.AnimalBehavior;
using Savanna.GameLogic.Interfaces;

namespace Savanna.GameLogic
{
    public class MoveAnimalCatch : IMoveAnimalCatch
    {
        private readonly IRandom _random;
        private readonly IConsoleFacade _consoleFacade;
        private readonly IConstants _constants;
        public MoveAnimalCatch(IRandom random, IConsoleFacade consoleFacade, IConstants constants)
        {
            _random = random;
            _consoleFacade = consoleFacade;
            _constants = constants;
        }

        public void AnimalCatchMove(List<IAnimal> animals, IField Field, IAnimalHealth animalHealth)
        {
            int step = _constants.AnimalCatchStep;

            foreach (var animalCatch in animals.Where(animal => animal.RunOrCatch == "Catch"))
            {
                bool isAnimalsAround = CheckAnimalsAround(animalCatch, animals, animalHealth);

                if (!isAnimalsAround)
                {
                    int newX = GetNewX(animalCatch, step, Field.Height);
                    int newY = GetNewY(animalCatch, step, Field.Width);

                    if (newX >= 0 && newX < Field.Height && newY >= 0 && newY < Field.Width)
                    {
                        bool isPositionFree = true;
                        foreach (var animal in animals)
                        {
                            if (animal.X == newX && animal.Y == newY)
                            {
                                isPositionFree = false;
                                break;
                            }
                        }

                        if (isPositionFree)
                        {
                            animalCatch.X = newX;
                            animalCatch.Y = newY;
                        }
                    }
                }
            }
        }

        private bool CheckAnimalsAround(IAnimal? animalCatch, List<IAnimal> animals, IAnimalHealth animalHealth)
        {
            foreach (var otherAnimal in animals.Where(animal => animal.RunOrCatch != "Catch"))
            {
                for (int x = -2; x < 3; x++)
                {
                    for (int y = -2; y < 3; y++)
                    {
                        if (x == 0 && y == 0)
                        {
                            continue;
                        }
                        else if (animalCatch.X - x == otherAnimal.X && animalCatch.Y - y == otherAnimal.Y && otherAnimal.IsAlive)
                        {
                            CatchAnimal(animalCatch, otherAnimal, animalHealth);
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return false;
        }

        private void CatchAnimal(IAnimal animalCatch, IAnimal otherAnimal, IAnimalHealth animalHealth)
        {
            animalCatch.X = otherAnimal.X;
            animalCatch.Y = otherAnimal.Y;
            otherAnimal.IsAlive = false;
            animalHealth.IncreaseHealth(animalCatch);
            _consoleFacade.WriteLine("\nAnimal catched!");
        }

        private int GetNewX(IAnimal? animalCatch, int step, int fieldHeight)
        {
            int newX;
            if (animalCatch.X == 0)
            {
                newX = animalCatch.X + step;
            }
            else if (animalCatch.X == fieldHeight - 1)
            {
                newX = animalCatch.X - step;
            }
            else
            {
                step = _random.GetRandomInt(-2, 3);
                newX = animalCatch.X + step;
            }

            return newX;
        }

        private int GetNewY(IAnimal? animalCatch, int step, int fieldWidth)
        {
            int newY;
            if (animalCatch.Y == 0)
            {
                newY = animalCatch.Y + step;
            }
            else if (animalCatch.Y == fieldWidth - 1)
            {
                newY = animalCatch.Y - step;
            }
            else
            {
                step = _random.GetRandomInt(-2, 3);
                newY = animalCatch.Y + step;
            }

            return newY;
        }
    }
}
