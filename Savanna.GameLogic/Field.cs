using Savanna.AnimalBehavior;
using Savanna.GameLogic.Interfaces;

namespace Savanna.GameLogic
{
    public class Field : IField
    {
        private readonly IConsoleFacade _consoleFacade;
        public int Height { get; set; }
        public int Width { get; set; }
        public char[,] InitializedField { get; set; }

        public Field()
        {
            //default constructor
        }

        public Field(int height, int width, IConsoleFacade consoleFacade)
        {
            Height = height;
            Width = width;
            InitializedField = new char[height, width];
            _consoleFacade = consoleFacade;
        }

        public void InitializeField(int height, int width)
        {
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    InitializedField[x, y] = ' ';
                }
            }
        }

        public void DisplayField(List<IAnimal> animals)
        {
            InitializeField(Height, Width);
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    char cellContent = InitializedField[x, y];

                    foreach (var animal in animals)
                    {
                        if (animal.X == x && animal.Y == y && animal.IsAlive)
                        {
                            cellContent = animal.Symbol;
                            InitializedField[x, y] = cellContent;
                        }
                    }

                    _consoleFacade.WriteField(cellContent);
                }
                _consoleFacade.WriteEmptyLine();
            }
        }
    }
}
