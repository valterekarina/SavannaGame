using Savanna.AnimalBehavior;
using Savanna.GameLogic.Interfaces;

namespace Savanna.GameLogic
{
    public class MoveAnimalRun : IMoveAnimalRun
    {
        private readonly IRandom _random;
        private readonly IConstants _constants;
        public MoveAnimalRun(IRandom random, IConstants constants)
        {
            _random = random;
            _constants = constants;
        }

        public void AnimalRunMove(List<IAnimal> animals, IField Field)
        {
            int step = _constants.AnimalRunStep;


            foreach (var animalRun in animals.Where(animal => animal.RunOrCatch == "Run"))
            {
                bool isAnimalCatchAround = CheckAnimalCatchAround(animalRun, animals, step, Field);

                if (!isAnimalCatchAround)
                {
                    int newX = GetNewX(animalRun, step, Field.Height);
                    int newY = GetNewY(animalRun, step, Field.Width);

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
                            animalRun.X = newX;
                            animalRun.Y = newY;
                        }
                    }
                }
            }
        }

        private bool CheckAnimalCatchAround(IAnimal? animalRun, List<IAnimal> animals, int step, IField Field)
        {
            foreach (var animalCatch in animals.Where(animal => animal.RunOrCatch == "Catch"))
            {
                for (int x = -1; x < 2; x++)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        if (x == 0 && y == 0)
                        {
                            continue;
                        }
                        else if (animalRun.X - x == animalCatch.X && animalRun.Y - y == animalCatch.Y)
                        {
                            RunAway(animalRun, animalCatch, step, Field);
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

        private void RunAway(IAnimal animalRun, IAnimal animalCatch, int step, IField Field)
        {
            if (animalCatch.X < animalRun.X && animalRun.X != Field.Height - 1)
            {
                animalRun.X += step;
            }
            else if (animalCatch.X > animalRun.X && animalRun.X != 0)
            {
                animalRun.X -= step;
            }

            if (animalCatch.Y < animalRun.Y && animalRun.Y != Field.Width - 1)
            {
                animalRun.Y += step;
            }
            else if (animalCatch.Y > animalRun.Y && animalRun.Y != 0)
            {
                animalRun.Y -= step;
            }
        }

        private int GetNewX(IAnimal? animalRun, int step, int fieldHeight)
        {
            int newX;
            if (animalRun.X == 0)
            {
                newX = animalRun.X + step;
            }
            else if (animalRun.X == fieldHeight - 1)
            {
                newX = animalRun.X - step;
            }
            else
            {
                step = _random.GetRandomInt(-1, 2);
                newX = animalRun.X + step;
            }

            return newX;
        }

        private int GetNewY(IAnimal? animalRun, int step, int fieldWidth)
        {
            int newY;
            if (animalRun.Y == 0)
            {
                newY = animalRun.Y + step;
            }
            else if (animalRun.Y == fieldWidth - 1)
            {
                newY = animalRun.Y - step;
            }
            else
            {
                step = _random.GetRandomInt(-1, 2);
                newY = animalRun.Y + step;
            }

            return newY;
        }
    }
}
