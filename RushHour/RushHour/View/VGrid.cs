using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Widget used to show grid and contain vehicles' widget
    /// </summary>
    class VGrid : WidgetsManager
    {
        /// <summary>
        /// dimension of this widget
        /// </summary>
        public int length, height;

        /// <summary>
        /// dimension of a grid's square
        /// </summary>
        public int blength, bheight;

        /// <summary>
        /// model grid
        /// </summary>
        public MGrid mGrid;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="BLength">length of a grid's square</param>
        /// <param name="BHeight">height of a grid's square</param>
        /// <param name="Grid">model grid</param>
        public VGrid(int BLength, int BHeight, MGrid Grid) : base("Grid", 6 * (BLength + 1) + 2, 6 * (BHeight + 1) + 2, false)
        {
            
            length = 6 * (BLength + 1) + 1;
            height = 6 * (BHeight + 1) + 1;
            blength = BLength;
            bheight = BHeight;
            mGrid = Grid;


            Content = GridContent(mGrid);

        }

        /// <summary>
        /// create grid in content and add vehicle's widget
        /// </summary>
        /// <param name="Grid"></param>
        /// <returns>content of grid</returns>
        public string GridContent(MGrid Grid)
        {
            string content = "";
            
            for (int i = 0; i<height; i++)
            {
                for (int j = 0; j<length; j++)
                {
                    //corner top left and bottom exit
                    if ((i == 0 && j == 0) ||
                        (i == 3 * (bheight + 1) && j == length - 1))
                        content += "\u250C";
                    //corner top right
                    else if (i == 0 && j == length - 1)
                        content += "\u2510";
                    //corner bottom left and exit top
                    else if ((i == height - 1 && j == 0) ||
                            (i == 2 * (bheight + 1) && j == length - 1))
                        content += "\u2514";
                    //corner bottom right
                    else if (i == height - 1 && j == length - 1)
                        content += "\u2518";
                    //horizontal side
                    else if (i == 0 || i == height - 1)
                        content += "\u2500";
                    //vertical side
                    else if ((j == 0) || (j == length - 1) &&
                                (i > 3 * (bheight + 1) || i < 2 * (bheight + 1)))
                        content += "\u2502";
                    //inner
                    else
                        content += " ";
                }
                content += "\n";
            }
            
            //add vehicle's widget
            foreach (MVehicle vehicle in Grid.Vehicles)
            {
                ShowVehicle(vehicle);
            }

            return content;
        }

        /// <summary>
        /// Add vehicle widget to grid
        /// </summary>
        /// <param name="vehicle">model of vehicle</param>
        public void ShowVehicle(MVehicle vehicle)
        {
            //position in console
            int[] pos = new int[2];
            pos[0] = (vehicle.VehicleDirection == MMain.Direction.North) ? (vehicle.Pos[1] - (vehicle.Length) + 1) * (bheight + 1) : vehicle.Pos[1] * bheight;
            pos[1] = (vehicle.VehicleDirection == MMain.Direction.West) ? (vehicle.Pos[0] - (vehicle.Length) + 1) * (blength + 1) : vehicle.Pos[0] * (blength);

            //add widget to grid
            AddWidget(new VVehicle(vehicle, this), pos[0], pos[1]);
        }

        /// <summary>
        /// Refresh content on screen
        /// </summary>
        /// <param name="contentNames">widget's names to update</param>
        /// <param name="delete">delete update (default = false)</param>
        public override void RefreshContentOnScreen(string[] contentNames, bool delete = false)
        {
            //vehicle currently updated
            VVehicle currentV;

            if (!delete)
            {
                foreach (string name in contentNames)
                {
                    // get widget 
                    currentV = (VVehicle)FindWidgetWithName(name);

                    // draw vehicle
                    currentV.DrawVehicle();

                    //position on console
                    int[] pos = new int[2];
                    pos[0] = (currentV.Vehicle.VehicleDirection == MMain.Direction.North) ? (currentV.Vehicle.Pos[1] - (currentV.Vehicle.Length - 1)) * (bheight + 1) : currentV.Vehicle.Pos[1] * (bheight + 1);
                    pos[1] = (currentV.Vehicle.VehicleDirection == MMain.Direction.West) ? (currentV.Vehicle.Pos[0] - (currentV.Vehicle.Length - 1)) * (blength + 1) : currentV.Vehicle.Pos[0] * (blength + 1);
                    currentV.Position = new int[] { pos[0], pos[1] };
                }
            }
            
            base.RefreshContentOnScreen(contentNames);
        }
    }
}
