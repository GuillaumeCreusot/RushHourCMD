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
        public bool IsSelected { get; set; }

        //Constructor
        public MVehicle(MGrid grid, int id, int length, MMain.Direction direction, int x, int y, bool isPlayer)
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
            this.VehicleDirection = direction;

            this.pos = new int[2];
            this.pos[0] = x;
            this.pos[1] = y;

            this.isPlayer = isPlayer;
            if (this.Length == 2)
            {
                this.name = "Voiture";
            }
            else
            {
                this.name = "Camion";
            }
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
                pos = value;
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
                vehicleDirection = value;
            }
        }

        //Methods
        public void Move(MMain.Direction direction)
        {

            //fonction ValidDirection
            if (assignedGrid.ValidDirection(this, direction))
            {
                //stay in range
                if (direction == MMain.Direction.North)
                {
                    pos[1] += 1;
                }
                else if (direction == MMain.Direction.South)
                {
                    pos[1] -= 1;
                }
                else if (direction == MMain.Direction.West)
                {
                    pos[0] -= 1;
                }
                else if (direction == MMain.Direction.East)
                {
                    pos[1] += 1;
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
            return this.Length + "," + this.Pos[0] + "," + this.Pos[1] + ","+ dir2 + "," + this.isPlayer;
        }

        /// <summary>
        /// takes the string from save file and turns it into a vehicle: ex: this.length = input[0].
        /// </summary>
        public void BackwardsString(string input)
        {

        }

    }
}
