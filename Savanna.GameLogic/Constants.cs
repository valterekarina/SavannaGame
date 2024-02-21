using Savanna.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savanna.GameLogic
{
    public class Constants : IConstants
    {
        public int AnimalCatchStep { get { return 2; }} 
        public int AnimalRunStep { get { return 1; }}
    }
}
