using Savanna.AnimalBehavior;
using Savanna.GameLogic.Interfaces;

namespace Savanna.GameLogic
{
    public class UserInputHandler : IUserInputHandler, IGetInput
    {
        private readonly IAnimalBirth _animalBirth;
        private readonly IConsoleFacade _consoleFacade;

        public UserInputHandler(IAnimalBirth animalBirth, IConsoleFacade consoleFacade)
        {
            _animalBirth = animalBirth;
            _consoleFacade = consoleFacade;
        }

        public string GetInput()
        {
            return _consoleFacade.ReadLine();
        }

        public int ChooseFieldHeight(IGetInput getInput)
        {
            _consoleFacade.Write("\nPlease input field height: ");
            bool validInput = false;
            int height = 0;

            while (!validInput)
            {
                string heightInput = getInput.GetInput();
                height = CheckHeight(heightInput);
                if (height > 0)
                {
                    validInput = true;
                }

            }
            return height;
        }

        public int CheckHeight(string heightInput)
        {
            if (int.TryParse(heightInput.Trim(), out int height) && height > 0)
            {
                return height;
            }
            else
            {
                _consoleFacade.Write("\nPlease enter positive integer: ");
                return 0;
            }
        }

        public int ChooseFieldWidth(IGetInput getInput)
        {
            _consoleFacade.Write("\nPlease input field width: ");
            bool validInput = false;
            int width = 0;

            while (!validInput)
            {
                string widthInput = getInput.GetInput();

                width = CheckWidth(widthInput);
                if (width > 0)
                {
                    validInput = true;
                }
            }
            return width;
        }

        public int CheckWidth(string widthInput)
        {
            if (int.TryParse(widthInput.Trim(), out int width) && width > 0)
            {
                return width;
            }
            else
            {
                _consoleFacade.Write("\nPlease enter positive integer: ");
                return 0;
            }
        }

        public void AddAnimal(List<IAnimal> animals, IField field, List<IAnimal> animalsCatch, List<IAnimal> animalsRun, Dictionary<Type, (string, ConsoleKey)> animalType)
        {
            if (_consoleFacade.KeyPressed())
            {
                ConsoleKeyInfo key = _consoleFacade.ReadKey(true);
                foreach (var type in animalType)
                {
                    if (key.Key.Equals(type.Value.Item2))
                    {
                        Type typeAnimal = type.Key;
                        if (type.Value.Item1.Trim() == "Run")
                        {
                            _animalBirth.BirthAnimal(animals, typeAnimal, animalsRun, field);
                        }
                        else if (type.Value.Item1.Trim() == "Catch")
                        {
                            _animalBirth.BirthAnimal(animals, typeAnimal, animalsCatch, field);
                        }
                    }
                }
            }
        }

        public string[] GetLocationPath()
        {
            _consoleFacade.Write("\nPlease enter file location: ");
            string fileLocation = GetInput();
            _consoleFacade.Write("\nPlease enter file name: ");
            string fileName = GetInput();
            var fileLocationArray = new string[] { Path.Combine(fileLocation, fileName) };

            return fileLocationArray;
        }

        public string NeedLoad()
        {
            _consoleFacade.Write("Do you want to load any animal? (y/n) ");
            return GetInput();
        }
    }
}
