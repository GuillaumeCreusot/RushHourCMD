using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    static class StandardGrids
    {
        //length, starting position X, position Y column, direction
        public static int[,] easyGrid = { { 3, 5, 4, (int)MMain.Direction.North } };
        public static int[,] easyGrid2 = { { 3, 5, 2, (int)MMain.Direction.North }, { 3, 5, 5, (int)MMain.Direction.West }, { 2, 3, 4, (int)MMain.Direction.South } };


        public static int[,] mediumGrid = { { 3, 1, 0, (int)MMain.Direction.South }, { 3, 5, 0, (int)MMain.Direction.East }, { 2, 1, 2, (int)MMain.Direction.South }, { 2, 0, 3, (int)MMain.Direction.East }, { 2, 1, 4, (int)MMain.Direction.West }, { 3, 4, 3, (int)MMain.Direction.North }, { 3, 2, 5, (int)MMain.Direction.South } };
        public static int[,] hardGrid = { { 2, 5, 0, (int)MMain.Direction.North }, { 2, 3, 0, (int)MMain.Direction.East }, { 2, 3, 3, (int)MMain.Direction.West }, { 2, 1, 2, (int)MMain.Direction.East }, { 3, 0, 5, (int)MMain.Direction.West }, { 2, 1, 5, (int)MMain.Direction.West }, { 2, 5, 3, (int)MMain.Direction.North }, { 2, 5, 5, (int)MMain.Direction.West }, { 3, 4, 4, (int)MMain.Direction.North }, { 3, 2, 5, (int)MMain.Direction.South } };



    }
}
