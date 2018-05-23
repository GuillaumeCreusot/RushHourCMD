using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    //Victory Screen
    class VVictory : Label
    {
        /// <summary>
        /// text on screen
        /// </summary>
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
        /// <summary>
        /// dimension of text
        /// </summary>
        public static int[] dimText = WidgetUtility.DimContent(text);

        public VVictory():base("Escape Menu", text, dimText[0], dimText[1])
        {

        }
    }
}
