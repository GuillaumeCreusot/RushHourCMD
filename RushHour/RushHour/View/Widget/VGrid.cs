using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VGrid : WidgetsManager
    {
        public int length, height, blength, bheight;
        public MGrid mGrid;

        public VGrid(int BLength, int BHeight, MGrid Grid) : base("Grid", 6 * (BLength + 1) + 2, 6 * (BHeight + 1) + 2, false)
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
                ShowVehicle(vehicle);
            }

            int[] dim = WidgetUtility.DimContent(content);

            return content;
        }


        public void ShowVehicle(MVehicle vehicle)
        {
            int[] pos = new int[2];
            pos[0] = (vehicle.VehicleDirection == MMain.Direction.North) ? (vehicle.Pos[1] - (vehicle.Length - 1)) : vehicle.Pos[1];
            pos[1] = (vehicle.VehicleDirection == MMain.Direction.West) ? (vehicle.Pos[0] - (vehicle.Length - 1)) : vehicle.Pos[0];
            AddWidget(new VVehicle(vehicle, this), pos[0] * (bheight), pos[1] * (blength));
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

        public override void RefreshContentOnScreen(string[] contentNames, bool delete = false)
        {
            VVehicle currentV;

            if (!delete)
            {
                foreach (string name in contentNames)
                {
                    currentV = (VVehicle)FindWidgetWithName(name);
                    currentV.DrawVehicle();

                    int[] pos = new int[2];
                    pos[0] = (currentV.Vehicle.VehicleDirection == MMain.Direction.North) ? (currentV.Vehicle.Pos[1] - currentV.Vehicle.Length) : currentV.Vehicle.Pos[1];
                    pos[1] = (currentV.Vehicle.VehicleDirection == MMain.Direction.West) ? (currentV.Vehicle.Pos[0] - currentV.Vehicle.Length) : currentV.Vehicle.Pos[0];
                    currentV.Position = new int[] { pos[0] * (bheight + 1), pos[1] * (blength + 1) };
                }
            }
            
            base.RefreshContentOnScreen(contentNames);
        }
    }
}
