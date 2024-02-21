using Savanna.AnimalBehavior;

namespace Savanna.GameLogic.Interfaces
{
    public interface IField
    {
        int Height { get; set; }
        int Width { get; set; }
        char[,] InitializedField { get; set; }
        void InitializeField(int height, int width);
        void DisplayField(List<IAnimal> animals);
    }
}
