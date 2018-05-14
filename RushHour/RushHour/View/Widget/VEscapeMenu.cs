using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VEscapeMenu: Menu
    {
        public static string text = @"
                                .______      ___      __    __       _______. _______ 
                                |   _  \    /   \    |  |  |  |     /       ||   ____|
                                |  |_)  |  /  ^  \   |  |  |  |    |   (----`|  |__   
                                |   ___/  /  /_\  \  |  |  |  |     \   \    |   __|  
                                |  |     /  _____  \ |  `--'  | .----)   |   |  |____ 
                                | _|    /__/     \__\ \______/  |_______/    |_______|
                                                                                     

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
        public static int[] dimText = WidgetUtility.DimContent(text);
        public static string[] itemName = { "Revenir au jeu", "Nouvelle partie", "Quitter" };

        public VEscapeMenu():base("Escape Menu", "", itemName.Length + 1, 30, itemName, margeLeft : 10)
        {

        }
    }
}
