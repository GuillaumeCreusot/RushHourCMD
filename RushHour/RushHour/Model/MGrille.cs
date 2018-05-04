using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.Model
{
    class MGrid
    {
        public int XLength {get; private set; }
        public int YLength { get; private set; }

        public bool[,] gridCollision;

        public List<MVehicle> Vehicles;




    }
}
