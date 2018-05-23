using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Menu activate when player push escape
    /// </summary>
    class VEscapeMenu : Menu
    {
        /// <summary>
        /// text above menu
        /// </summary>
        public static string text = @"

                                        ██████╗  █████╗ ██╗   ██╗███████╗███████╗
                                        ██╔══██╗██╔══██╗██║   ██║██╔════╝██╔════╝
                                        ██████╔╝███████║██║   ██║███████╗█████╗  
                                        ██╔═══╝ ██╔══██║██║   ██║╚════██║██╔══╝  
                                        ██║     ██║  ██║╚██████╔╝███████║███████╗
                                        ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝
                                         

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
        /// <summary>
        /// dimension of the text above menu
        /// </summary>
        public static int[] dimText = WidgetUtility.DimContent(text);
        /// <summary>
        /// item's name show in menu
        /// </summary>
        public static string[] itemName = { "Revenir au jeu", "Sauvegarder et continuer", "Sauvegarder et quitter", "Nouvelle Partie", "Quitter" };

        /// <summary>
        /// Constructor
        /// </summary>
        public VEscapeMenu():base("Escape Menu", "", itemName.Length + 1, 40, itemName, margeLeft : 10)
        {

        }
    }
}
