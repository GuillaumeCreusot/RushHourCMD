using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    interface IView
    {
        void ShowMainMenu();

        void ShowGameScreen();

        void ShowEscMenu();

        void ShowSaveMenu();

        void ShowLoadMenu();

        void ShowMoveVehicle();

        void ShowSelectVehicle();

        void ShowSelectMenu();
    }
}
