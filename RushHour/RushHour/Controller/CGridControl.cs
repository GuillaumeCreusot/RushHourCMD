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
        public VScore score;
        public VLegend legend;
        public VTitle title;
        public VGojira gozilla;

        //Constructor
        public CGridControl(MGrid grid)
        {
            mGrid = grid;
            vGrid = new VGrid(10, 6, mGrid);

            manager = new WidgetsManager("Grid", Console.LargestWindowWidth, Console.LargestWindowHeight);

            manager.AddWidgetsManager(vGrid, VTitle.dimText[0] + 10, Console.LargestWindowWidth/2 - vGrid.ColumnSpanMax/2);

            int[] dim = WidgetUtility.DimContent(InGameText.score);
            manager.AddWidget(new Label("lbScore", InGameText.score, dim[0], dim[1]), 0, 1);

            score = new VScore("score", grid);
            manager.AddWidgetsManager(score, dim[0], 1);

            legend = new VLegend();
            manager.AddWidget(legend, Console.LargestWindowHeight - VLegend.dimText[0], 1);

            title = new VTitle();
            manager.AddWidget(title, 0, Console.LargestWindowWidth / 2 - title.ColumnSpanMax / 2);

            //gozilla = new VGojira();
            //manager.AddWidget(gozilla, 0, Console.LargestWindowWidth - VGojira.dimText[0] - 1);
        }

        /// <summary>
        /// Selects a car to move
        /// </summary>
        /// <returns></returns>
        public int Control()
        {
            mGrid.SelectedItem = 0;

            string lastSelectedItem = "";

            Console.Clear();
            manager.RefreshContentOnScreen();
            vGrid.RefreshContentOnScreen();
            score.RefreshContentOnScreen();

            while (!mGrid.IsVictoryAchieved())
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
                        mGrid.Vehicles[mGrid.SelectedItem].IsMoving = true;
                        MoveControl();
                        mGrid.Vehicles[mGrid.SelectedItem].IsMoving = false;
                        break;

                    case ConsoleKey.Escape:
                        return 1;
                        break;

                }
            }

            if (mGrid.IsVictoryAchieved())
            {
                return 2;
            }

            return 0;
        }

        /// <summary>
        /// Move vehicle with directional arrows
        /// </summary>
        public void MoveControl()
        {
            MVehicle v = mGrid.GetVehicle(mGrid.SelectedItem);
            bool flagVictoire = false;
            vGrid.DeleteWidgetOnScreen(mGrid.SelectedItem.ToString());
            vGrid.RefreshContentOnScreen(mGrid.SelectedItem.ToString());
            while (!flagVictoire)
            {
                score.RefreshContentOnScreen();
                
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
                flagVictoire = mGrid.IsVictoryAchieved();
                if (mGrid.SelectedItem.ToString() != "0")
                {
                    vGrid.RefreshContentOnScreen("0");
                }
                
                vGrid.DeleteWidgetOnScreen(mGrid.SelectedItem.ToString());
                vGrid.RefreshContentOnScreen(mGrid.SelectedItem.ToString());
            }
        }
    }
}
