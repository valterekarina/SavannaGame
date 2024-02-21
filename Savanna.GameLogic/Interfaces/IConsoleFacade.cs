using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savanna.GameLogic.Interfaces
{
    public interface IConsoleFacade
    {
        void Clear();
        void Write(string text);
        void WriteField(char text);
        void WriteLine(string text);
        void WriteEmptyLine();
        string ReadLine();
        ConsoleKeyInfo ReadKey(bool readkey);
        bool KeyPressed();
    }
}
