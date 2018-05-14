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
            manager = new WidgetsManager("Main Menu", Console.LargestWindowWidth, Console.LargestWindowHeight);
            manager.AddWidget(mainMenu, 0, 0);
        }

        public void Control()
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
                        //launch according processus --> return a certain value ??
                        break;

                }
                
            }
        }
    }
}
