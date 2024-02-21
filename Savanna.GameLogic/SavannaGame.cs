using Savanna.AnimalBehavior;
using Savanna.GameLogic.Interfaces;
using System.Reflection;

namespace Savanna.GameLogic
{
    public class SavannaGame : ISavannaGame
    {
        public IField Field { get; set; }
        private readonly IUserInputHandler _userInputHandler;
        private readonly IGetAnimal _getAnimal;
        private readonly IMoveAnimalRun _moveAnimalRun;
        private readonly IMoveAnimalCatch _moveAnimalCatch;
        private readonly IGetInput _getInput;
        private readonly IAnimalHealth _animalHealth;
        private readonly IAnimalBirth _birth;
        private readonly IConsoleFacade _consoleFacade;
        public List<IAnimal> Animals { get; set; } = new List<IAnimal>();
        public List<IAnimal> AnimalsCatch { get; set; } = new List<IAnimal>();
        public List<IAnimal> AnimalsRun { get; set; } = new List<IAnimal>();
        public SavannaGame(IField field, IUserInputHandler userInputHandler,
            IGetAnimal getAnimal, IMoveAnimalRun moveAnimalRun,
            IMoveAnimalCatch moveAnimalCatch, IGetInput getInput,
            IAnimalHealth animalHealth, IAnimalBirth animalBirth,
            IConsoleFacade consoleFacade)
        {
            Field = field;
            _userInputHandler = userInputHandler;
            _getAnimal = getAnimal;
            _moveAnimalRun = moveAnimalRun;
            _moveAnimalCatch = moveAnimalCatch;
            _getInput = getInput;
            _animalHealth = animalHealth;
            _birth = animalBirth;
            _consoleFacade = consoleFacade;
        }

        public void Run()
        {
            PluginLoadContext();


            int height = _userInputHandler.ChooseFieldHeight(_getInput);
            int width = _userInputHandler.ChooseFieldWidth(_getInput);
            Field = new Field(height, width, _consoleFacade);

            _consoleFacade.Clear();

            Dictionary<Type, (string, ConsoleKey)> animalType = AnimalTypeScanner.GetAllAnimalTypes();
            foreach (var pair in animalType)
            {
                _consoleFacade.WriteLine("To add " + pair.Key.Name + " press " + pair.Value.Item2);
            }
            _consoleFacade.WriteLine("To start Savana Game, press enter");
            _consoleFacade.ReadLine();

            while (true)
            {
                _consoleFacade.Clear();
                _userInputHandler.AddAnimal(Animals, Field, AnimalsCatch, AnimalsRun, animalType);

                Field.DisplayField(Animals);
                _animalHealth.ShowHealthMetrics(Animals);

                _getAnimal.GetAnimalByType(Animals, AnimalsCatch, AnimalsRun);

                if (AnimalsRun.Count > 0)
                {
                    _moveAnimalRun.AnimalRunMove(Animals, Field);
                    Thread.Sleep(500);
                    _consoleFacade.Clear();
                    Field.DisplayField(Animals);
                    _animalHealth.ShowHealthMetrics(Animals);
                }

                if (AnimalsCatch.Count > 0)
                {
                    _moveAnimalCatch.AnimalCatchMove(Animals, Field, _animalHealth);
                }

                _animalHealth.DecreaseHealth(Animals);
                _animalHealth.IsAnimalAlive(Animals);
                _birth.CheckNear(AnimalsCatch, Animals, Field);
                _birth.CheckNear(AnimalsRun, Animals, Field);

                Thread.Sleep(500);
            }
        }

        private void PluginLoadContext()
        {
            var ifLoad = _userInputHandler.NeedLoad();
            if (ifLoad == "y" || ifLoad == "Y")
            {
                try
                {
                    var loadLocation = _userInputHandler.GetLocationPath();
                    IEnumerable<IAnimal> animals = loadLocation.SelectMany(pluginPath =>
                    {
                        Assembly pluginAssembly = LoadPlugin(pluginPath);
                        return CreateCommands(pluginAssembly);
                    }).ToList();
                }
                catch (Exception ex)
                {
                    _consoleFacade.WriteLine(ex.ToString());
                }
            }
        }

        static Assembly LoadPlugin(string pluginPath)
        {
            var pluginLocation = pluginPath;
            var loadContext = new PluginLoad(pluginLocation);
            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
        }

        static IEnumerable<IAnimal> CreateCommands(Assembly assembly)
        {
            int count = 0;
            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IAnimal).IsAssignableFrom(type))
                {
                    IAnimal result = Activator.CreateInstance(type) as IAnimal;
                    if (result != null)
                    {
                        count++;
                        yield
                        return result;
                    }
                }
            }
        }
    }
}
