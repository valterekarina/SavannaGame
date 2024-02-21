using Savanna.AnimalBehavior;

namespace Savanna.GameLogic.Interfaces
{
    public interface IUserInputHandler
    {
        void AddAnimal(List<IAnimal> animals, IField field, List<IAnimal> animalsCatch, List<IAnimal> animalsRun, Dictionary<Type, (string, ConsoleKey)> animalType);
        int ChooseFieldHeight(IGetInput getInput);
        int ChooseFieldWidth(IGetInput getInput);
        int CheckHeight(string heightInput);
        int CheckWidth(string widthInput);
        string[] GetLocationPath();
        string NeedLoad();
    }
}
