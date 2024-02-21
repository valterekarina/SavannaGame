using Savanna.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savanna.GameLogic
{
    public class ConsoleFacade : IConsoleFacade
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteField(char text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
        
        public void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public ConsoleKeyInfo ReadKey(bool readkey)
        {
            return Console.ReadKey(readkey);
        }

        public bool KeyPressed()
        {
            return Console.KeyAvailable;
        }
    }
}
