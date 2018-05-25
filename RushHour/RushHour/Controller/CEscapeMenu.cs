using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class CEscapeMenu
    {
        public VEscapeMenu escape;
        public WidgetsManager manager;

        //Constructor
        public CEscapeMenu()
        {
            escape = new VEscapeMenu();
            Label permanentText = new Label("permanent text", VEscapeMenu.text, VEscapeMenu.dimText[0] + 1, VEscapeMenu.dimText[1]);
            manager = new WidgetsManager("Escape Menu", Console.LargestWindowWidth, Console.LargestWindowHeight);
            manager.AddWidget(permanentText, (Console.LargestWindowHeight - VEscapeMenu.dimText[0]) / 4, (Console.LargestWindowWidth / 2) - (VEscapeMenu.dimText[1] / 2));
            manager.AddWidget(escape, (Console.LargestWindowHeight - VEscapeMenu.dimText[0]) / 4 + VEscapeMenu.dimText[0] + 2, (Console.LargestWindowWidth / 2) - (VEscapeMenu.dimText[1] / 2));
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
                        if (escape.SelectedItem == 0)
                        {
                            escape.SelectedItem = escape.NbItem - 1;
                        }
                        else
                        {
                            escape.SelectedItem--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (escape.SelectedItem == escape.NbItem - 1)
                        {
                            escape.SelectedItem = 0;
                        }
                        else
                        {
                            escape.SelectedItem++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        return escape.SelectedItem;

                }

            }
        }
    }
}
