using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VDifficultyMenu : Menu
    {

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
        public static int[] dimText = WidgetUtility.DimContent(text);
        public static string[] itemName = { "Facile", "Moyenne", "Difficile" };

        public VDifficultyMenu(): base("Difficulty Menu", "", itemName.Length + 1, 30, itemName, margeLeft : 10)
        {

        }
    }
}
