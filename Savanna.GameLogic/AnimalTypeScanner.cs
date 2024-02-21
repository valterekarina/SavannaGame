using Savanna.AnimalBehavior;
using System.Reflection;

namespace Savanna.GameLogic
{
    public class AnimalTypeScanner
    {
        public static Dictionary<Type, (string RunOrCatch, ConsoleKey AnimalConsoleKey)> GetAllAnimalTypes()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var animalTypesAndRunOrCatch = new Dictionary<Type, (string, ConsoleKey)>();


            foreach (Assembly assembly in assemblies)
            {
                Type[] animalTypes = assembly.GetTypes()
                .Where(type => typeof(IAnimal).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                .ToArray();

                foreach (var animalType in animalTypes)
                {
                    PropertyInfo runOrCatch = animalType.GetProperty("RunOrCatch");
                    PropertyInfo consoleKey = animalType.GetProperty("ConsoleKey");

                    if (runOrCatch != null && consoleKey != null)
                    {
                        string animalRunOrCatch = (string)runOrCatch.GetValue(Activator.CreateInstance(animalType));
                        ConsoleKey animalConsoleKey = (ConsoleKey)consoleKey.GetValue(Activator.CreateInstance(animalType));
                        animalTypesAndRunOrCatch.Add(animalType, (animalRunOrCatch, animalConsoleKey));
                    }
                }
            }
            return animalTypesAndRunOrCatch;
        }
    }
}
