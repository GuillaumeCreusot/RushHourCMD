using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class MVehicle
    {
        private int idVehicle;
        private String name;
        private int length;
        private int[] pos; //X and Y position on the grid
        private MMain.Direction vehicleDirection;
        private bool isPlayer;
        private MGrid assignedGrid;
        private bool placeOnGrid;
        public bool IsSelected { get; set; }

        //Constructor
        public MVehicle(MGrid grid, int id, int length, MMain.Direction direction, bool isPlayer)
        {
            this.assignedGrid = grid;
            this.idVehicle = id;
            if (length == 2 || length == 3)
            {
                this.Length = length;
            }
            else
            {
                this.Length = 3;
                Console.WriteLine("Invalid length: vehicle length initialised to 3.");
            }

            this.vehicleDirection = direction;

            this.pos = new int[2];

            this.isPlayer = isPlayer;
            if (this.Length == 2)
            {
                this.name = "Voiture";
            }
            else
            {
                this.name = "Camion";
            }

            placeOnGrid = false;
        }

        // Properties
        public int IdVehicle
        {
            get
            {
                return idVehicle;
            }

            set
            {
                idVehicle = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public int[] Pos
        {
            get
            {
                return pos;
            }

            set
            {
                if (placeOnGrid)
                {
                    assignedGrid.ModifyVehicleInCollisionGrid(idVehicle, false);
                }

                if (assignedGrid.IsValidPosition(value[0], value[1], VehicleDirection, Length))
                {
                    pos = value;
                    assignedGrid.ModifyVehicleInCollisionGrid(idVehicle, true);
                    placeOnGrid = true;
                }
                else
                {
                    throw new Exception("Position out of range");
                }
            }
        }

        public bool IsPlayer
        {
            get
            {
                return isPlayer;
            }

            set
            {
                isPlayer = value;
            }
        }

        public MGrid AssignedGrid
        {
            get
            {
                return assignedGrid;
            }

            set
            {
                assignedGrid = value;
            }
        }

        public MMain.Direction VehicleDirection
        {
            get
            {
                return vehicleDirection;
            }
            set
            {
                if (assignedGrid.IsValidPosition(Pos[0], Pos[1], value, Length))
                {
                    vehicleDirection = value;
                }
                else
                {
                    throw new Exception("Direction invalide");
                }
            }
        }

        //Methods
        public void Move(MMain.Direction direction)
        {

            //stay in range
            if(VehicleDirection == MMain.Direction.North || VehicleDirection == MMain.Direction.South)
            {
                //the furthest vehicle's case to the north
                int vNorth = VehicleDirection == MMain.Direction.North ? Pos[1] - (Length - 1) : Pos[1];
                //the furthest vehicle's case to the south
                int vSouth = VehicleDirection == MMain.Direction.South ? Pos[1] + (Length - 1) : Pos[1];

                if (direction == MMain.Direction.North && vNorth - 1 >= 0 && !assignedGrid.gridCollision[Pos[0], vNorth - 1] )
                {
                    Pos = new int[] {Pos[0], Pos[1] - 1 };
                    assignedGrid.Score++;
                }
                else if (direction == MMain.Direction.South && vSouth + 1 < assignedGrid.gridCollision.GetLength(1) && !assignedGrid.gridCollision[Pos[0], vSouth + 1])
                {
                    Pos = new int[] { Pos[0], Pos[1] + 1 };
                    assignedGrid.Score++;
                }
            }
            else
            {
                //the furthest vehicle's case to the west
                int vWest = VehicleDirection == MMain.Direction.West ? Pos[0] - (Length - 1) : Pos[0];
                //the furthest vehicle's case to the east
                int vEast = VehicleDirection == MMain.Direction.East ? Pos[0] + (Length - 1) : Pos[0];

                if (direction == MMain.Direction.West && vWest - 1 >= 0 && !assignedGrid.gridCollision[vWest - 1, Pos[1]])
                {
                    Pos = new int[] { Pos[0] -1, Pos[1]};
                    assignedGrid.Score++;
                }
                else if (direction == MMain.Direction.East && vEast + 1 < assignedGrid.gridCollision.GetLength(0) && !assignedGrid.gridCollision[vEast + 1, Pos[1]])
                {
                    Pos = new int[] { Pos[0] + 1, Pos[1]};
                    assignedGrid.Score++;
                }
            }

        }

        /// <summary>
        /// returns relevent info of vehicle : length, Xpos, Ypos, direction. Works only if width or heigth of grid doesn't exceed 2 digits. TODO: eventually fix ?
        /// </summary>
        public override string ToString()
        {
            int dir = (int)vehicleDirection;
            string dir2 = dir.ToString();
            return this.Length + "" + this.Pos[0] + "" + this.Pos[1] + ""+ dir2 + "" + this.isPlayer;
        }

        /// <summary>
        /// takes the string from save file and turns it into a vehicle: ex: this.length = input[0].
        /// </summary>
        public void BackwardsString(string input)
        {

        }

    }
}
