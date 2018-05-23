using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Menu used to save party
    /// </summary>
    class VSaveMenu : Label
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
                                                                          


        ███████╗ █████╗ ██╗   ██╗██╗   ██╗███████╗ ██████╗  █████╗ ██████╗ ██████╗ ███████╗
        ██╔════╝██╔══██╗██║   ██║██║   ██║██╔════╝██╔════╝ ██╔══██╗██╔══██╗██╔══██╗██╔════╝
        ███████╗███████║██║   ██║██║   ██║█████╗  ██║  ███╗███████║██████╔╝██║  ██║█████╗  
        ╚════██║██╔══██║██║   ██║╚██╗ ██╔╝██╔══╝  ██║   ██║██╔══██║██╔══██╗██║  ██║██╔══╝  
        ███████║██║  ██║╚██████╔╝ ╚████╔╝ ███████╗╚██████╔╝██║  ██║██║  ██║██████╔╝███████╗
        ╚══════╝╚═╝  ╚═╝ ╚═════╝   ╚═══╝  ╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚══════╝
                                                

                                   
         Entrez le nom de votre sauvegarde (chiffres et lettres uniquement) :
                                    
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
        /// cursor's position where the player can write the name of the save's file
        /// </summary>
        public int[] cursorPosition;

        public VSaveMenu(): base("Save Menu", "", dimText[0] + 2, dimText[1])
        {
            cursorPosition = new int[2] { dimText[0] + 1, dimText[1] / 2 };
        }
    }
}
