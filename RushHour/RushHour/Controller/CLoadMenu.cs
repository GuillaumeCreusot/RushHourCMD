using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RushHour
{
    class CLoadMenu
    {
        public VLoadMenu menu;
        public WidgetsManager manager;

        //Constructor
        public CLoadMenu()
        {
            menu = new VLoadMenu();
            Label permanentText = new Label("permanent text", VLoadMenu.text, VLoadMenu.dimText[0] + 1, VLoadMenu.dimText[1]);
            manager = new WidgetsManager("Load Menu", Console.LargestWindowWidth, Console.LargestWindowHeight);
            manager.AddWidget(permanentText, 0, (Console.LargestWindowWidth / 2) - (VLoadMenu.dimText[1] / 2));
            manager.AddWidget(menu, VLoadMenu.dimText[0] + 2, (Console.LargestWindowWidth / 2) - (VLoadMenu.dimText[1] / 2));
        }

        /// <summary>
        /// Navigate through options
        /// </summary>
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
