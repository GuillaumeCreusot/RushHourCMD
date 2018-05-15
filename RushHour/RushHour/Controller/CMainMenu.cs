using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class CMainMenu
    {
        public VMainMenu mainMenu;
        public WidgetsManager manager;

        public CMainMenu()
        {            
            mainMenu = new VMainMenu();
            Label permanentText = new Label("permanent text", VMainMenu.text, VMainMenu.dimText[0] + 1, VMainMenu.dimText[1]);
            manager = new WidgetsManager("Main Menu", Console.LargestWindowWidth, Console.LargestWindowHeight);
            manager.AddWidget(permanentText, 0, 0);
            manager.AddWidget(mainMenu, VMainMenu.dimText[0] + 2, 0);
        }

        public int Control()
        {
            manager.RefreshContentOnScreen();
            while(true)
            {
                ConsoleKeyInfo k = Console.ReadKey();
                switch (k.Key)
                    {
                    case ConsoleKey.UpArrow:
                        if (mainMenu.SelectedItem == 0)
                        {
                            mainMenu.SelectedItem = mainMenu.NbItem - 1;
                        }
                        else
                        {
                            mainMenu.SelectedItem--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (mainMenu.SelectedItem == mainMenu.NbItem - 1)
                        {
                            mainMenu.SelectedItem = 0;
                        }
                        else
                        {
                            mainMenu.SelectedItem++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();                    
                        return mainMenu.SelectedItem;

                }
                
            }
            
        }
    }
}
