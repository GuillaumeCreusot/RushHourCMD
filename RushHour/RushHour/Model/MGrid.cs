using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class MGrid
    {
        public int XLength {get; private set; }
        public int YLength { get; private set; }

        public bool[,] gridCollision;

        public List<MVehicle> Vehicles;

        public bool ValidDirection(MVehicle vehicle, MMain.Direction direction)
        {
            int x = vehicle.Pos[0];
            int y = vehicle.Pos[1];
            if (vehicle.VehicleDirection == direction || (int)vehicle.VehicleDirection == ((int)direction + 2) % 4)
            {
                if (direction == MMain.Direction.North) //North
                    if (y - 1 >= 0)
                        return !this[x, y - 1];

                if (direction == MMain.Direction.West) //West
                    if (x - 1 >= 0)
                        return !this[x - 1, y ];

                if (direction == MMain.Direction.South) //South
                    if (y + 1 <= YLength)
                        return !this[x, y + 1];

                if (direction == MMain.Direction.East) //East
                    if (x + 1 <= XLength)
                        return !this[x + 1, y];
            }

            return false;
        }

        //Builder
        public MGrid(int X, int Y)
        {
            XLength = X;
            YLength = Y;
            gridCollision = new bool[XLength, YLength];
            Vehicles = new List<MVehicle>();
        }


        //Index
        public bool this[int x, int y]
        {
            get
            {
                return gridCollision[x, y];
            }
        }


    }
}
