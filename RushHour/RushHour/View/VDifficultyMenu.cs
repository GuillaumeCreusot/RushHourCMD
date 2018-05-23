using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Menu used to choice difficulty level
    /// </summary>
    class VDifficultyMenu : Menu
    {
        /// <summary>
        /// text above menu
        /// </summary>
        public static string text = @"
        ██████╗ ███████╗       ███████╗██╗  ██╗ ██████╗ ██╗    ██╗███████╗██████╗ 
        ██╔══██╗██╔════╝██╗    ██╔════╝██║  ██║██╔═══██╗██║    ██║██╔════╝██╔══██╗
        ██████╔╝█████╗  ╚═╝    ███████╗███████║██║   ██║██║ █╗ ██║█████╗  ██████╔╝
        ██╔══██╗██╔══╝  ██╗    ╚════██║██╔══██║██║   ██║██║███╗██║██╔══╝  ██╔══██╗
        ██║  ██║███████╗╚═╝    ███████║██║  ██║╚██████╔╝╚███╔███╔╝███████╗██║  ██║
        ╚═╝  ╚═╝╚══════╝       ╚══════╝╚═╝  ╚═╝ ╚═════╝  ╚══╝╚══╝ ╚══════╝╚═╝  ╚═╝
                                                                                  


            ██████╗ ██╗███████╗███████╗██╗ ██████╗██╗   ██╗██╗  ████████╗███████╗
            ██╔══██╗██║██╔════╝██╔════╝██║██╔════╝██║   ██║██║  ╚══██╔══╝██╔════╝
            ██║  ██║██║█████╗  █████╗  ██║██║     ██║   ██║██║     ██║   █████╗  
            ██║  ██║██║██╔══╝  ██╔══╝  ██║██║     ██║   ██║██║     ██║   ██╔══╝  
            ██████╔╝██║██║     ██║     ██║╚██████╗╚██████╔╝███████╗██║   ███████╗
            ╚═════╝ ╚═╝╚═╝     ╚═╝     ╚═╝ ╚═════╝ ╚═════╝ ╚══════╝╚═╝   ╚══════╝
                                                                     


                               Choisissez la difficulté :        
                                    
            ";
        /// <summary>
        /// dimension of the text above menu
        /// </summary>
        public static int[] dimText = WidgetUtility.DimContent(text);

        /// <summary>
        /// item's name show in menu
        /// </summary>
        public static string[] itemName = { "Facile", "Moyenne", "Difficile" };

        /// <summary>
        /// Constructor
        /// </summary>
        public VDifficultyMenu(): base("Difficulty Menu", "", itemName.Length + 1, 30, itemName, margeLeft : 10)
        {

        }
    }
}
