using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VGameOver: Menu
    {
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
        public static int[] dimText = WidgetUtility.DimContent(text);
        public static string[] itemName = { "" };

        public VGameOver(): base("Quit Menu", "", itemName.Length + 1, 30, itemName, margeLeft : 10)
        {

        }
    }
}
