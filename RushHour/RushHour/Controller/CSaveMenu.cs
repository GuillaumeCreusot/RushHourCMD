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

        //Constructor
        public CSaveMenu()
        {
            saveMenu = new VSaveMenu();
            Label permanentText = new Label("permanent text", VSaveMenu.text, VSaveMenu.dimText[0] + 1, VSaveMenu.dimText[1]);
            manager = new WidgetsManager("Save Menu", Console.LargestWindowWidth, Console.LargestWindowHeight);
            manager.AddWidget(permanentText, (Console.LargestWindowHeight - VSaveMenu.dimText[0])/ 4, (Console.LargestWindowWidth / 2) - (VSaveMenu.dimText[1] / 2));
            manager.AddWidget(saveMenu, (Console.LargestWindowHeight - VSaveMenu.dimText[0]) / 4 + VSaveMenu.dimText[0] + 2, (Console.LargestWindowWidth / 2) - (VSaveMenu.dimText[1] / 2));
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
                    Console.Clear();
                    manager.RefreshContentOnScreen();

                    if (hasSpecialChar(input))
                    {
                        Console.WriteLine("Le nom ne doit pas contenir de caractères spéciaux.");
                    }
                    Console.CursorTop = saveMenu.cursorPosition[0];
                    Console.CursorLeft = saveMenu.cursorPosition[1];
                    input = Console.ReadLine();
                }
                while (hasSpecialChar(input));
                return input;
            }

        }

        /// <summary>
        /// Test if the given string has any special characters
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool hasSpecialChar(string text)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_, ";
            foreach (var car in specialChar)
            {
                if (text.Contains(car)) return true;
            }
            return false;
        }
    }
}

