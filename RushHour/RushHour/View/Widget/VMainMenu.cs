using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VMainMenu : Widget
    {
        public VMainMenu() : base("Main Menu", Console.LargestWindowHeight, Console.LargestWindowWidth)
        {
            this.Content = @"
   ▄████████ ███    █▄     ▄████████    ▄█    █▄            ▄█    █▄     ▄██████▄  ███    █▄     ▄████████ 
  ███    ███ ███    ███   ███    ███   ███    ███          ███    ███   ███    ███ ███    ███   ███    ███ 
  ███    ███ ███    ███   ███    █▀    ███    ███          ███    ███   ███    ███ ███    ███   ███    ███ 
 ▄███▄▄▄▄██▀ ███    ███   ███         ▄███▄▄▄▄███▄▄       ▄███▄▄▄▄███▄▄ ███    ███ ███    ███  ▄███▄▄▄▄██▀ 
▀▀███▀▀▀▀▀   ███    ███ ▀███████████ ▀▀███▀▀▀▀███▀       ▀▀███▀▀▀▀███▀  ███    ███ ███    ███ ▀▀███▀▀▀▀▀   
▀███████████ ███    ███          ███   ███    ███          ███    ███   ███    ███ ███    ███ ▀███████████ 
  ███    ███ ███    ███    ▄█    ███   ███    ███          ███    ███   ███    ███ ███    ███   ███    ███ 
  ███    ███ ████████▀   ▄████████▀    ███    █▀           ███    █▀     ▀██████▀  ████████▀    ███    ███ 
  ███    ███                                                                                    ███    ███ 


                                Frayez vous un chemin dans ce traffic infernal !

                                    _________________________________________________
                            /|     |                                                 |
                            ||     |          Jumbotron team, 2018                   |
                        .----|-----,|                 Guillaume Creusot Offical       |
                        ||  ||   ==||                 H                               |
                    .-----'--'|   ==||                SachaRaptor                      |
                    |)-      ~|     ||_________________________________________________|
                    | ___     |     |____...==..._  >\______________________________|
                    [_/.-.\'--'-------- //.-.  .-.\\/   |/            \\ .-.  .-. //
                    (o)`=== '''''''''`( o )( o )     o              `( o )( o )` 
                    '-'                '-'  '-'                       '-'  '-'

                                                                                                       
                                    
            ";
        }

        public void Display()
        {
            string[] menuItems = { "Nouvelle partie", "Charger une partie", "Régler la difficulté" };
            DisplayOptions(menuItems, this.Content);
        }
    }
}
