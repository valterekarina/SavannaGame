using Savanna.GameLogic.Interfaces;

namespace Savanna.GameLogic
{
    public class StepRandom : IRandom
    {
        private readonly Random _random;
        public StepRandom()
        {
            _random = new Random();
        }
        public int GetRandomInt(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
