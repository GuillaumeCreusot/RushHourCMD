using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Label when player quit the game
    /// </summary>
    class VGameOver: Label
    {
        /// <summary>
        /// text show in label
        /// </summary>
        public static string text = @"
            ██████╗ ███████╗       ███████╗██╗  ██╗ ██████╗ ██╗    ██╗███████╗██████╗ 
            ██╔══██╗██╔════╝██╗    ██╔════╝██║  ██║██╔═══██╗██║    ██║██╔════╝██╔══██╗
            ██████╔╝█████╗  ╚═╝    ███████╗███████║██║   ██║██║ █╗ ██║█████╗  ██████╔╝
            ██╔══██╗██╔══╝  ██╗    ╚════██║██╔══██║██║   ██║██║███╗██║██╔══╝  ██╔══██╗
            ██║  ██║███████╗╚═╝    ███████║██║  ██║╚██████╔╝╚███╔███╔╝███████╗██║  ██║
            ╚═╝  ╚═╝╚══════╝       ╚══════╝╚═╝  ╚═╝ ╚═════╝  ╚══╝╚══╝ ╚══════╝╚═╝  ╚═╝
                                 


            ███████╗██╗███╗   ██╗    ██████╗ ██╗   ██╗         ██╗███████╗██╗   ██╗
            ██╔════╝██║████╗  ██║    ██╔══██╗██║   ██║         ██║██╔════╝██║   ██║
            █████╗  ██║██╔██╗ ██║    ██║  ██║██║   ██║         ██║█████╗  ██║   ██║
            ██╔══╝  ██║██║╚██╗██║    ██║  ██║██║   ██║    ██   ██║██╔══╝  ██║   ██║
            ██║     ██║██║ ╚████║    ██████╔╝╚██████╔╝    ╚█████╔╝███████╗╚██████╔╝
            ╚═╝     ╚═╝╚═╝  ╚═══╝    ╚═════╝  ╚═════╝      ╚════╝ ╚══════╝ ╚═════╝ 


                                   
                Espérons que les gens se gareront mieux la prochaine fois...
                                    
            ";

        /// <summary>
        /// dimension of the text above menu
        /// </summary>
        public static int[] dimText = WidgetUtility.DimContent(text);

        /// <summary>
        /// item's name show in menu
        /// </summary>
        public static string[] itemName = { "" };

        /// <summary>
        /// Constructor
        /// </summary>
        public VGameOver(): base("Quit Menu", "", dimText[0], dimText[1])
        {

        }
    }
}
