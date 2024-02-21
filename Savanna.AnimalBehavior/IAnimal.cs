namespace Savanna.AnimalBehavior
{
    public interface IAnimal
    {
        bool IsAlive { get; set; }
        int X { get; set; }
        int Y { get; set; }
        char Symbol { get; }
        double Health { get; set; }
        string RunOrCatch { get; }
        int IsNearTime { get; set; }
        ConsoleKey ConsoleKey { get; }
    }
}
