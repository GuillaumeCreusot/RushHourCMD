using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class CDifficultyMenu
    {

        public VDifficultyMenu diff;
        public WidgetsManager manager;

        public CDifficultyMenu()
        {
            diff = new VDifficultyMenu();
            Label permanentText = new Label("permanent text", VDifficultyMenu.text, VDifficultyMenu.dimText[0] + 1, VDifficultyMenu.dimText[1]);
            manager = new WidgetsManager("Difficulty Menu", Console.LargestWindowWidth, Console.LargestWindowHeight);
            manager.AddWidget(permanentText, 0, (Console.LargestWindowWidth / 2) - (VDifficultyMenu.dimText[1] / 2));
            manager.AddWidget(diff, VDifficultyMenu.dimText[0] + 2, (Console.LargestWindowWidth / 2) - (VDifficultyMenu.dimText[1] / 2));
        }

        public MMain.Difficulty Control()
        {
            manager.RefreshContentOnScreen();
            while (true)
            {
                ConsoleKeyInfo k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (diff.SelectedItem == 0)
                        {
                            diff.SelectedItem = diff.NbItem - 1;
                        }
                        else
                        {
                            diff.SelectedItem--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (diff.SelectedItem == diff.NbItem - 1)
                        {
                            diff.SelectedItem = 0;
                        }
                        else
                        {
                            diff.SelectedItem++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        if (diff.SelectedItem == 0)
                        {
                            return MMain.Difficulty.Easy;
                        }
                        else if (diff.SelectedItem == 1)
                        {
                            return MMain.Difficulty.Medium;
                        }
                        else
                        {
                            return MMain.Difficulty.Hard;
                        }

                }

            }
        }
    }
}
