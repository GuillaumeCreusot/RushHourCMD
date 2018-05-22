﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VLoadMenu : Menu
    {
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
        public static int[] dimText = WidgetUtility.DimContent(text);
        private static string[] itemName = MGame.ListSaves();

        public VLoadMenu() : base("Load Menu", "", itemName.Length + 1, 50, itemName, margeLeft: 10)
        {

        }
    }
}
