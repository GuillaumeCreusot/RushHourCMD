using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class CVictory
    {
        public VVictory menu;
        public WidgetsManager manager;

        public CVictory()
        {
            menu = new VVictory();
            Label permanentText = new Label("permanent text", VVictory.text, VVictory.dimText[0] + 1, VVictory.dimText[1]);
            manager = new WidgetsManager("Victory Menu", Console.LargestWindowWidth, Console.LargestWindowHeight);
            manager.AddWidget(permanentText, 0, (Console.LargestWindowWidth / 2) - (VVictory.dimText[1] / 2));
            manager.AddWidget(menu, VVictory.dimText[0] + 2, (Console.LargestWindowWidth / 2) - (VVictory.dimText[1] / 2));
        }

        public int Control()
        {
            manager.RefreshContentOnScreen();
            while (true)
            {
                ConsoleKeyInfo k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (menu.SelectedItem == 0)
                        {
                            menu.SelectedItem = menu.NbItem - 1;
                        }
                        else
                        {
                            menu.SelectedItem--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (menu.SelectedItem == menu.NbItem - 1)
                        {
                            menu.SelectedItem = 0;
                        }
                        else
                        {
                            menu.SelectedItem++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        return menu.SelectedItem;
                }
            }
        }
    }
}
