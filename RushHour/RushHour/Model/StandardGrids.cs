using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    static class StandardGrids
    {
        //length, starting position x, position y column, direction
        public static int[,] easyGrid = { 
            { 2, 1, 2, (int)MMain.Direction.East},
            { 2, 4, 1, (int)MMain.Direction.South},
            { 3, 5, 0, (int)MMain.Direction.South },
            { 2, 4, 4, (int)MMain.Direction.East }
        };

        public static int[,] mediumGrid = {
            { 2, 1, 2, (int)MMain.Direction.East},
            { 2, 0, 0, (int)MMain.Direction.East },
            { 2, 2, 0, (int)MMain.Direction.South },
            { 3, 3, 0, (int)MMain.Direction.South },
            { 3, 0, 1, (int)MMain.Direction.South },
            { 3, 1, 3, (int)MMain.Direction.East},
            { 3, 3, 5, (int)MMain.Direction.East },
        };
        public static int[,] hardGrid = {
            {2, 1, 2, (int)MMain.Direction.East },
            { 2, 0, 2, (int)MMain.Direction.South },
            { 2, 0, 4, (int)MMain.Direction.East},
            { 3, 2, 3, (int)MMain.Direction.South },
            { 2, 3, 1, (int)MMain.Direction.South },
            { 2, 3, 3, (int)MMain.Direction.East },
            { 3, 3, 0, (int)MMain.Direction.East },
            { 2, 4, 1, (int)MMain.Direction.East },
            { 3, 5, 2, (int)MMain.Direction.South},
            { 3, 3, 5, (int)MMain.Direction.East }
        };

        public static MMain.Direction Direction(int dir)
        {
            if (dir == 0)
                return MMain.Direction.North;
            if (dir == 1)
                return MMain.Direction.West;
            if (dir == 2)
                return MMain.Direction.East;

            return MMain.Direction.South;
        }

    }
}
