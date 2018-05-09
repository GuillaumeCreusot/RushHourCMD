using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VMainMenu : Menu
    {
        public static string text = @"
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
        public static int[] dimText = WidgetUtility.DimContent(text);
        public static string[] itemName = { "Nouvelle Partie", "Continuer", "Quitter" };

        public VMainMenu():base("Main Menu", text, dimText[0] + 1 + itemName.Length, dimText[1] + 10, itemName)
        {
            
        }
    }
}
