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

        public CEscapeMenu()
        {
            escape = new VEscapeMenu();
            Label permanentText = new Label("permanent text", VEscapeMenu.text, VEscapeMenu.dimText[0] + 1, VEscapeMenu.dimText[1]);
            manager = new WidgetsManager("Escape Menu", Console.LargestWindowWidth, Console.LargestWindowHeight);
            manager.AddWidget(permanentText, 0, 0);
            manager.AddWidget(escape, VEscapeMenu.dimText[0] + 2, 0);
        }

        public void Control()
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
                        //launch according processus --> return a certain value ??
                        break;

                }

            }
        }
    }
}
