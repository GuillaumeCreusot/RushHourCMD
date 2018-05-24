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
            manager.AddWidget(permanentText, (Console.LargestWindowHeight - VVictory.dimText[0]) / 4, (Console.LargestWindowWidth / 2) - (VVictory.dimText[1] / 2));
            manager.AddWidget(menu, VVictory.dimText[0] + 2, (Console.LargestWindowWidth / 2) - (VVictory.dimText[1] / 2));
        }

        public void Control()
        {
            manager.RefreshContentOnScreen();
            Console.ReadKey();
            //Console.Clear();
            //CGameOver gameOver = new CGameOver();
        }
    }
}
