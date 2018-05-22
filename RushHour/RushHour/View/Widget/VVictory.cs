using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VVictory : Menu
    {

        public static string text = @"
                    ██╗     ██╗██╗  ██╗███████╗     █████╗     ██████╗  ██████╗ ███████╗███████╗██╗
                    ██║     ██║██║ ██╔╝██╔════╝    ██╔══██╗    ██╔══██╗██╔═══██╗██╔════╝██╔════╝██║
                    ██║     ██║█████╔╝ █████╗      ███████║    ██████╔╝██║   ██║███████╗███████╗██║
                    ██║     ██║██╔═██╗ ██╔══╝      ██╔══██║    ██╔══██╗██║   ██║╚════██║╚════██║╚═╝
                    ███████╗██║██║  ██╗███████╗    ██║  ██║    ██████╔╝╚██████╔╝███████║███████║██╗
                    ╚══════╝╚═╝╚═╝  ╚═╝╚══════╝    ╚═╝  ╚═╝    ╚═════╝  ╚═════╝ ╚══════╝╚══════╝╚═╝
                                                                               

                                    _________________________________________________
                            /|     |                                                 |
                            ||     |          On a rarement vu quelqu'un             |
                        .----|-----,|         sortir de son créneau aussi bien.       |
                        ||  ||   ==||                  Félicitations !                |
                    .-----'--'|   ==||                                                 |
                    |)-      ~|     ||_________________________________________________|
                    | ___     |     |____...==..._  >\______________________________|
                    [_/.-.\'--'-------- //.-.  .-.\\/   |/            \\ .-.  .-. //
                    (o)`=== '''''''''`( o )( o )     o              `( o )( o )` 
                    '-'                '-'  '-'                       '-'  '-'
                                                                                                      
                                    
            ";
        public static int[] dimText = WidgetUtility.DimContent(text);
        public static string[] itemName = { "" };

        public VVictory():base("Escape Menu", "", itemName.Length + 1, 30, itemName, margeLeft : 10)
        {

        }
    }
}
