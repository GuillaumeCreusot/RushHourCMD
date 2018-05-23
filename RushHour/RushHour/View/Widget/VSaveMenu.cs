using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VSaveMenu : Label
    {
        public static string text = @"
            ██████╗ ███████╗       ███████╗██╗  ██╗ ██████╗ ██╗    ██╗███████╗██████╗ 
            ██╔══██╗██╔════╝██╗    ██╔════╝██║  ██║██╔═══██╗██║    ██║██╔════╝██╔══██╗
            ██████╔╝█████╗  ╚═╝    ███████╗███████║██║   ██║██║ █╗ ██║█████╗  ██████╔╝
            ██╔══██╗██╔══╝  ██╗    ╚════██║██╔══██║██║   ██║██║███╗██║██╔══╝  ██╔══██╗
            ██║  ██║███████╗╚═╝    ███████║██║  ██║╚██████╔╝╚███╔███╔╝███████╗██║  ██║
            ╚═╝  ╚═╝╚══════╝       ╚══════╝╚═╝  ╚═╝ ╚═════╝  ╚══╝╚══╝ ╚══════╝╚═╝  ╚═╝
                                                                          


        ███████╗ █████╗ ██╗   ██╗██╗   ██╗███████╗ ██████╗  █████╗ ██████╗ ██████╗ ███████╗
        ██╔════╝██╔══██╗██║   ██║██║   ██║██╔════╝██╔════╝ ██╔══██╗██╔══██╗██╔══██╗██╔════╝
        ███████╗███████║██║   ██║██║   ██║█████╗  ██║  ███╗███████║██████╔╝██║  ██║█████╗  
        ╚════██║██╔══██║██║   ██║╚██╗ ██╔╝██╔══╝  ██║   ██║██╔══██║██╔══██╗██║  ██║██╔══╝  
        ███████║██║  ██║╚██████╔╝ ╚████╔╝ ███████╗╚██████╔╝██║  ██║██║  ██║██████╔╝███████╗
        ╚══════╝╚═╝  ╚═╝ ╚═════╝   ╚═══╝  ╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚══════╝
                                                

                                   
         Entrez le nom de votre sauvegarde (chiffres et lettres uniquement) :
                                    
            ";
        public static int[] dimText = WidgetUtility.DimContent(text);
        public static string[] itemName = { "" };

        public int[] cursorPosition;

        public VSaveMenu(): base("Save Menu", "", dimText[0] + 2, dimText[1])
        {
            cursorPosition = new int[2] { dimText[0] + 1, dimText[1] / 2 };
        }
    }
}
