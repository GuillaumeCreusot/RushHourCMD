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

        //Constructor
        public MVehicle(MGrid grid, int id, int length, MMain.Direction direction, int[] pos, bool isPlayer)
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
            this.pos = pos;
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

        internal MMain.Direction VehicleDirection { get => vehicleDirection; set => vehicleDirection = value; }

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

    }
}
