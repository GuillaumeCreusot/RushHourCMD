using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Main Menu
    /// </summary>
    class VMainMenu : Menu
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
        /// <summary>
        /// dimension of the text above menu
        /// </summary>
        public static int[] dimText = WidgetUtility.DimContent(text);

        /// <summary>
        /// item's name show in menu
        /// </summary>
        public static string[] itemName = { "Nouvelle Partie", "Continuer une partie", "Quitter" };

        /// <summary>
        /// Constructor
        /// </summary>
        public VMainMenu():base("Main Menu", "", itemName.Length + 1, 40, itemName, margeLeft : 10)
        {
            
        }
    }
}
