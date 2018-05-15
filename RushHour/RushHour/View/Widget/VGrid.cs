using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VGrid : Widget
    {
        public int length, height, blength, bheight;
        public MGrid mGrid;

        public VGrid(int BLength, int BHeight, MGrid Grid) : base("Grid", 6 * (BHeight + 1) + 2, 6 * (BLength + 1) + 2)
        {
            
            length = 6 * (BLength + 1) + 1;
            height = 6 * (BHeight + 1) + 1;
            blength = BLength;
            bheight = BHeight;
            mGrid = Grid;


            Content = GridContent(mGrid);

        }

        public void Update()
        {
            Content = GridContent(mGrid);
        }

        public string GridContent(MGrid Grid)
        {
            string content = "";

            for (int i = 0; i<height; i++)
            {
                for (int j = 0; j<length; j++)
                {
                    if (i % (bheight + 1) == 0)
                    {
                        if (j % (blength + 1) == 0)
                            content += "\u253C";
                        else
                            content += "\u2500";
                    }

                    else
                    {
                        if (j % (blength + 1) == 0)
                            content += "\u2502";
                        else
                            content += " ";
                    }
                }
                content += "\n";
            }

            foreach (MVehicle vehicle in Grid.Vehicles)
            {
                ShowVehicle(ref content, vehicle);
            }


            return content;
        }

        public void ShowVehicle(ref string content, MVehicle vehicle)
        {
            int x = vehicle.Pos[0];
            int y = vehicle.Pos[1];
            char chara = (vehicle.IsSelected) ? '\u2592' : '\u2588';
            int i = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            while (i < vehicle.Length)
            {

                for (int j = 0; j < blength; j++)
                    for (int k = 0; k < bheight; k++)
                    {
                        content = ReplaceAtIndex((y * (bheight + 1) + k + 1) * (length + 1) + x * (blength + 1) + j + 1, chara, content); //x * (blength + 1) + j + 1
                    }

                i++;
                if (vehicle.VehicleDirection == MMain.Direction.North)
                    y--;
                if (vehicle.VehicleDirection == MMain.Direction.East)
                    x++;
                if(vehicle.VehicleDirection == MMain.Direction.South)
                    y++;
                if (vehicle.VehicleDirection == MMain.Direction.West)
                    x--;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static string ReplaceAtIndex(int i, char value, string word)
        {
            /*Console.WriteLine(i);
            Console.WriteLine(word.Length);*/
            char[] letters = word.ToCharArray();
            if (letters[i] != '\n')
                letters[i] = value;

            return string.Join("", letters);
        }
    }
}
