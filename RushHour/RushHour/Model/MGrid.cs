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

        private int selectedItem;
        public int SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                Vehicles[selectedItem].IsSelected = false;
                Vehicles[value].IsSelected = true;
                selectedItem = value;
            }
        }

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

        //Builders
        public MGrid(int X, int Y)
        {
            XLength = X;
            YLength = Y;
            gridCollision = new bool[XLength, YLength];
            Vehicles = new List<MVehicle>();
        }

        public MGrid(int[,] vehicles, int X, int Y)
        {
            XLength = X;
            YLength = Y;
            gridCollision = new bool[XLength, YLength];
            Vehicles = new List<MVehicle>();

            for (int i = 0; i < vehicles.GetLength(0); i++)
            {
                MVehicle vehicle = new MVehicle(this, i, vehicles[i, 0], StandardGrids.Direction(vehicles[i, 3]), vehicles[i, 2], vehicles[i, 1], (i == 0) ? true : false);
                vehicle.IsSelected = (i == 0) ? true : false;
                Vehicles.Add(vehicle);
            }

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
