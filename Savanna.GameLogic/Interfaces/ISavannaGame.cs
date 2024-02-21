using Savanna.AnimalBehavior;

namespace Savanna.GameLogic.Interfaces
{
    public interface ISavannaGame
    {
        List<IAnimal> Animals { get; set; }
        List<IAnimal> AnimalsRun { get; set; }
        IField Field { get; set; }
        List<IAnimal> AnimalsCatch { get; set; }
        void Run();
    }
}