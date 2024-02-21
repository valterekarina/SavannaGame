namespace Savanna.AnimalBehavior
{
    public class Antelope : IAnimal
    {
        public bool IsAlive { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Health { get; set; }
        public char Symbol { get; } = 'A';
        public string RunOrCatch { get; } = "Run";
        public int IsNearTime { get; set; }
        public ConsoleKey ConsoleKey { get; } = ConsoleKey.A;
    }
}
