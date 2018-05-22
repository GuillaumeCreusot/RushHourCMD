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

        private int selectedItem = 0;
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
                AddVehicle(vehicles[i, 1], vehicles[i, 2], (MMain.Direction)vehicles[i, 3], vehicles[i, 0], i==0);
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

        public MVehicle GetVehicle(int idVehicule)
        {
            int i = 0;
            while(i < Vehicles.Count && Vehicles[i].IdVehicle != idVehicule)
            {
                i++;
            }

            if(i == Vehicles.Count)
            {
                return null;
            }
            else
            {
                return Vehicles[i];
            }
        }

        public void ModifyVehicleInCollisionGrid(int idVehicle, bool state)
        {
            MVehicle v = GetVehicle(idVehicle);

            if(v == null)
            {
                throw new Exception($"Le vehicule avec l'id {idVehicle} n'existe pas");
            }

            gridCollision[v.Pos[0], v.Pos[1]] = state;

            if (v.VehicleDirection == MMain.Direction.North) //North
            {
                gridCollision[v.Pos[0], v.Pos[1] - 1] = state;

                if(v.Length == 3)
                {
                    gridCollision[v.Pos[0], v.Pos[1] - 2] = state;
                }
            }


            if (v.VehicleDirection == MMain.Direction.West) //West
            {
                gridCollision[v.Pos[0] - 1, v.Pos[1]] = state;

                if (v.Length == 3)
                {
                    gridCollision[v.Pos[0] - 2, v.Pos[1]] = state;
                }
            }

            if (v.VehicleDirection == MMain.Direction.South) //South
            {
                gridCollision[v.Pos[0], v.Pos[1] + 1] = state;

                if (v.Length == 3)
                {
                    gridCollision[v.Pos[0], v.Pos[1] + 2] = state;
                }
            }

            if (v.VehicleDirection == MMain.Direction.East) //East
            {
                gridCollision[v.Pos[0] + 1, v.Pos[1]] = state;

                if (v.Length == 3)
                {
                    gridCollision[v.Pos[0] + 2, v.Pos[1]] = state;
                }
            }
        }

        public bool IsValidPosition(int x, int y)
        {
            return !gridCollision[x, y];
        }

        public bool IsValidPosition(int x, int y, MMain.Direction direction, int length)
        {
            if(IsValidPosition(x, y))
            {
                if (direction == MMain.Direction.North && y - length + 1 >= 0) //North
                {
                    if (length == 3)
                    {
                        return !gridCollision[x, y - 1] && !gridCollision[x, y - 2];
                    }
                    else
                    {
                        return !gridCollision[x, y - 1];
                    }
                }


                else if (direction == MMain.Direction.West && x - length + 1 >= 0) //West
                {
                    if (length == 3)
                    {
                        return !gridCollision[x - 1, y] && !gridCollision[x - 2, y];
                    }
                    else
                    {
                        return !gridCollision[x - 1, y];
                    }
                }

                else if (direction == MMain.Direction.South && y + length - 1 < gridCollision.GetLength(1)) //South
                {
                    if (length == 3)
                    {
                        return !gridCollision[x, y + 1] && !gridCollision[x, y + 2];
                    }
                    else
                    {
                        return !gridCollision[x, y + 1];
                    }
                }

                else if (direction == MMain.Direction.East && x + length - 1 < gridCollision.GetLength(0)) //East
                {
                    if (length == 3)
                    {
                        return !gridCollision[x + 1, y] && !gridCollision[x + 2, y];
                    }
                    else
                    {
                        return !gridCollision[x + 1, y];
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void AddVehicle(int x, int y, MMain.Direction direction, int length, bool isPlayer = false)
        {
            MVehicle v = new MVehicle(this, Vehicles.Count, length, direction, isPlayer);
            this.Vehicles.Add(v);
            v.Pos = new int[2] { x, y };
        }


    }
}
