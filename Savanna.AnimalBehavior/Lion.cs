namespace Savanna.AnimalBehavior
{
    public class Lion : IAnimal
    {
        public bool IsAlive { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Health { get; set; }
        public char Symbol { get; } = 'L';
        public string RunOrCatch { get; } = "Catch";
        public int IsNearTime { get; set; }
        public ConsoleKey ConsoleKey { get; } = ConsoleKey.L;
    }
}
