using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class CGridControl
    {
        public VGrid vGrid;
        public WidgetsManager manager;
        public MGrid mGrid;

        public CGridControl(MGrid grid)
        {
            mGrid = grid;
            vGrid = new VGrid(6, 6, mGrid);

            manager = new WidgetsManager("Grid", Console.LargestWindowWidth, Console.LargestWindowHeight);

            manager.AddWidget(vGrid, Console.LargestWindowHeight / 2 - vGrid.height / 2, (Console.LargestWindowWidth / 2) - (vGrid.length / 2));
            manager.RefreshContentOnScreen();


        }

        public void Control()
        {

            while (true)
            {
                vGrid.Update();
                manager.RefreshContentOnScreen();
                ConsoleKeyInfo k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (mGrid.SelectedItem == 0)
                            mGrid.SelectedItem = mGrid.Vehicles.Count - 1;

                        else
                            mGrid.SelectedItem--;

                        break;


                    case ConsoleKey.RightArrow:
                        if (mGrid.SelectedItem == mGrid.Vehicles.Count - 1)
                            mGrid.SelectedItem = 0;

                        else
                            mGrid.SelectedItem++;

                        break;

                    case ConsoleKey.Enter:
                        //launch according processus --> return a certain value ??
                        break;

                    case ConsoleKey.Escape:
                        //launch according processus --> return a certain value ??
                        break;

                }

                if (k.Key == ConsoleKey.Escape)
                    break;


            }
        }
    }
}
