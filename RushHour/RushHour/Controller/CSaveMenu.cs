using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class CSaveMenu
    {
        public VSaveMenu saveMenu;
        public WidgetsManager manager;

        public CSaveMenu()
        {
            saveMenu = new VSaveMenu();
            Label permanentText = new Label("permanent text", VSaveMenu.text, VSaveMenu.dimText[0] + 1, VSaveMenu.dimText[1]);
            manager = new WidgetsManager("Save Menu", Console.LargestWindowWidth, Console.LargestWindowHeight);
            manager.AddWidget(permanentText, 0, 0);
            manager.AddWidget(saveMenu, VSaveMenu.dimText[0] + 2, 0);
        }

        /// <summary>
        /// user input to get name of save
        /// </summary>
        /// <returns></returns>
        public string Control()
        {
            manager.RefreshContentOnScreen();
            while (true)
            {
                string input = "";
                do
                {
                    if (hasSpecialChar(input))
                    {
                        Console.WriteLine("Le nom ne doit pas contenir de caractères spéciaux.");
                    }
                    input = Console.ReadLine();
                }
                while (hasSpecialChar(input));
                return input;
            }

        }

        public bool hasSpecialChar(string text)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var car in specialChar)
            {
                if (text.Contains(car)) return true;
            }
            return false;
        }
    }
}

