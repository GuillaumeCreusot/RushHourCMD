using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VLegend : Label
    {   
        //Légende
        /// <summary>
        /// Instructions for the player
        /// </summary>
        public static string text = @"


Sélection des véhicules :





     ↑
    ←↓→   : Flèches directionnelles pour naviguer


   Enter  : Valider la sélection


   Escape : Afficher le menu Pause









Déplacement d'un véhicule selectionné :





     ↑
    ←↓→   : Flèches directionnelles pour déplacer


   Enter  : Retourner à la sélection

";
        //Dimensions Légende
        public static int[] dimText = WidgetUtility.DimContent(text);
        

        public VLegend() : base("Legend", text, dimText[0], dimText[1])
        {

        }
    }
}
