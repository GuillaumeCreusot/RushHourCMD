using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class Program
    {
        static void Main(string[] args)
        {
            /* TESTS WM*/
            WidgetsManager wm = new WidgetsManager("wm", Console.LargestWindowWidth, Console.LargestWindowHeight);
            MGrid grid = new MGrid(6, 6);
            VGrid vgrid = new VGrid(12, 6, grid);
            wm.AddWidget(vgrid, Console.LargestWindowHeight/2 - vgrid.height/2, (Console.LargestWindowWidth / 2) - (vgrid.length / 2));
            wm.RefreshContentOnScreen();


            /* TESTS MAIN MENU 
            VMainMenu menuTest = new VMainMenu();
            menuTest.Display();
            Console.ReadLine();*/

            /*TESTS GRILLE*/
            /*
            Console.WriteLine(vgrid.Content);

            */
            ///* TESTS MAIN MENU */
            //VMainMenu menuTest = new VMainMenu();
            //menuTest.Display();
            //Console.ReadLine();

            //test menu
            /*
            WidgetsManager wm = new WidgetsManager("wm", Console.LargestWindowWidth, Console.LargestWindowHeight);
            VMainMenu m = new VMainMenu();
            wm.AddWidget(m, 0, 0);
            wm.RefreshContentOnScreen();
            m.SelectedItem = 1;

            Console.ReadLine();*/
        }
    }
}
