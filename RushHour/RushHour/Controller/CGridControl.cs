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
            vGrid = new VGrid(12, 6, mGrid);

            manager = new WidgetsManager("Grid", Console.LargestWindowWidth, Console.LargestWindowHeight);

            manager.AddWidgetsManager(vGrid, Console.LargestWindowHeight/2 - vGrid.RowSpanMax/2, Console.LargestWindowWidth/2 - vGrid.ColumnSpanMax/2);  
        }

        public int Control()
        {
            mGrid.SelectedItem = 0;

            string lastSelectedItem = "";

            Console.Clear();
            manager.RefreshContentOnScreen();
            vGrid.RefreshContentOnScreen();

            while (true)
            {
                vGrid.RefreshContentOnScreen(mGrid.SelectedItem.ToString());
                if(lastSelectedItem != "")
                {
                    vGrid.RefreshContentOnScreen(lastSelectedItem);
                    lastSelectedItem = "";
                }

                ConsoleKeyInfo k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.LeftArrow:
                        lastSelectedItem = mGrid.SelectedItem.ToString();
                        if (mGrid.SelectedItem == 0)
                            mGrid.SelectedItem = mGrid.Vehicles.Count - 1;

                        else
                            mGrid.SelectedItem--;
                        
                        break;


                    case ConsoleKey.RightArrow:
                        lastSelectedItem = mGrid.SelectedItem.ToString();
                        if (mGrid.SelectedItem == mGrid.Vehicles.Count - 1)
                            mGrid.SelectedItem = 0;

                        else
                            mGrid.SelectedItem++;

                        break;

                    case ConsoleKey.Enter:
                        MoveControl();
                        break;

                    case ConsoleKey.Escape:
                        return 1;
                        break;

                }
            }

            return 0;
        }

        public void MoveControl()
        {
            MVehicle v = mGrid.GetVehicle(mGrid.SelectedItem);

            while (true)
            {
                vGrid.DeleteWidgetOnScreen(mGrid.SelectedItem.ToString());
                vGrid.RefreshContentOnScreen(mGrid.SelectedItem.ToString());
                ConsoleKeyInfo ck = Console.ReadKey();
                switch (ck.Key)
                {
                    case ConsoleKey.UpArrow:
                        v.Move(MMain.Direction.North);
                        break;

                    case ConsoleKey.DownArrow:
                        v.Move(MMain.Direction.South);
                        break;

                    case ConsoleKey.RightArrow:
                        v.Move(MMain.Direction.East);
                        break;

                    case ConsoleKey.LeftArrow:
                        v.Move(MMain.Direction.West);
                        break;

                    case ConsoleKey.Enter:
                        return;
                }
            }
        }
    }
}
