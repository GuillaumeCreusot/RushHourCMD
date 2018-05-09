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
            /* TESTS WM
            WidgetsManager wm = new WidgetsManager("test");
            Widget w = new Widget("test");

            wm.AddWidget(w, 1, 1);

            wm.Test();
            */

            /* TESTS MAIN MENU 
            VMainMenu menuTest = new VMainMenu();
            menuTest.Display();
            Console.ReadLine();*/

            /*TESTS GRILLE*/
            MGrid grid = new MGrid(6, 6);
            VGrid vgrid = new VGrid(6, 3, grid);
            Console.WriteLine(vgrid.Contenu);
        }
    }
}
