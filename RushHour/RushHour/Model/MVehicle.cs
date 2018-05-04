using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.Model
{
    class MVehicle
    {
        private int idVehicle;
        private String name;
        private int length;
        private int[] pos; //X and Y position on the grid
        private MDirection direction; //N, S, E, W
        private bool isPlayer;
        private MGrid grid;

        //Constructor
        public MVehicle(MGrid grid, int id, int length, MDirection direction, int[] pos, bool isPlayer)
        {
            this.Grid = grid;
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
            this.Direction = direction;
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

        public MDirection Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;
            }
        }

        public MGrid Grid
        {
            get
            {
                return grid;
            }

            set
            {
                grid = value;
            }
        }

        //Methods
        public void Move(MDirection direction)
        {

            //fonction ValidDirection
            if (grid.ValidDirection(this, direction))
            {
                //stay in range
                if (direction == North)
                {
                    pos[1] += 1;
                }
                else if (direction == South)
                {
                    pos[1] -= 1;
                }
                else if (direction == West)
                {
                    pos[0] -= 1;
                }
                else if (direction == East)
                {
                    pos[1] += 1;
                }               

            }
           
        }

    }
}
