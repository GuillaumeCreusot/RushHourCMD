using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class CGameOver
    {
        public VGameOver menu;
        public WidgetsManager manager;

        //Constructor
        public CGameOver()
        {
            menu = new VGameOver();
            Label permanentText = new Label("permanent text", VGameOver.text, VGameOver.dimText[0] + 1, VGameOver.dimText[1]);
            manager = new WidgetsManager("Game Over Menu", Console.LargestWindowWidth, Console.LargestWindowHeight);
            manager.AddWidget(permanentText, 0, (Console.LargestWindowWidth / 2) - (VGameOver.dimText[1] / 2));
            manager.AddWidget(menu, VGameOver.dimText[0] + 2, (Console.LargestWindowWidth / 2) - (VGameOver.dimText[1] / 2));
            manager.RefreshContentOnScreen();
        }
    }
}
