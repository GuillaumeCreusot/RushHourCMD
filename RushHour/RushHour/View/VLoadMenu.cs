﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Menu used to load a game
    /// </summary>
    class VLoadMenu : Menu
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
                                                                          

                         ██████╗██╗  ██╗ █████╗ ██████╗  ██████╗ ███████╗██████╗ 
                        ██╔════╝██║  ██║██╔══██╗██╔══██╗██╔════╝ ██╔════╝██╔══██╗
                        ██║     ███████║███████║██████╔╝██║  ███╗█████╗  ██████╔╝
                        ██║     ██╔══██║██╔══██║██╔══██╗██║   ██║██╔══╝  ██╔══██╗
                        ╚██████╗██║  ██║██║  ██║██║  ██║╚██████╔╝███████╗██║  ██║
                         ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝
                                                                                       

                                   
                                    Choisissez la partie à charger !                                    
            ";
        /// <summary>
        /// dimensions of the text above menu
        /// </summary>
        public static int[] dimText = WidgetUtility.DimContent(text);

        /// <summary>
        /// item's name shown in menu
        /// </summary>
        private static string[] itemName = MGame.ListSaves();

        /// <summary>
        /// Constructor
        /// </summary>
        public VLoadMenu() : base("Load Menu", "", itemName.Length + 1, 50, itemName, margeLeft: 10)
        {

        }
    }
}
