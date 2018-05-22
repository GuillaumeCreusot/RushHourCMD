using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VVehicle : Widget
    {
        private MVehicle vehicle;

        public MVehicle Vehicle
        {
            get
            {
                return vehicle;
            }
        }

        public VVehicle(MVehicle veh, VGrid master) : base(veh.IdVehicle.ToString()
            , (veh.VehicleDirection == MMain.Direction.North
                || veh.VehicleDirection == MMain.Direction.South)?(master.bheight + 1) * veh.Length + 1         //WTF
            : master.bheight + 1
            , !(veh.VehicleDirection == MMain.Direction.North
                || veh.VehicleDirection == MMain.Direction.South) ? (master.blength + 1) * veh.Length + 1       
            : master.blength + 1)
        {
            vehicle = veh;
            Master = master;
            BasicColor = (veh.IsPlayer)?ConsoleColor.White:(ConsoleColor) (veh.IdVehicle % 14 + 1);
            DrawVehicle();
        }

        public void RefreshPosition()
        {
            Position = vehicle.Pos;
        }
        
        public void DrawVehicle()
        {
            string content = "";
            char chara = (vehicle.IsSelected) ? '\u2592' : '\u2588';

            VGrid master = (VGrid)Master;
            bool test = vehicle.VehicleDirection == MMain.Direction.North
                || vehicle.VehicleDirection == MMain.Direction.South;

            for (int i = 0; i < (test? (master.bheight + 1) * vehicle.Length +1
                : master.bheight + 1); i++)
            {
                for(int j = 0; j < (!test ? (master.blength + 1) * vehicle.Length +1
                : master.blength + 1); j++)
                {
                    if( i == 0 || j == 0 
                        || i  == master.height - 1 || j == master.length - 1 
                        || (i % (master.bheight + 1) == 0 && j % (master.blength + 1) == 0)
                        || (i % (master.bheight + 1) == 0 && !(test && i != (master.bheight + 1) * vehicle.Length))
                        || (j % (master.blength + 1) == 0 && !(!test && j != (master.blength + 1) * vehicle.Length))
                        )
                    {
                        content += "\u0000";
                    }
                    else
                    {
                        if (vehicle.Length == 2)
                        {
                            if (test)
                            {
                                if ((j <= 2 || j >= master.blength - 1) && (
                                    (i == ((master.bheight + 1) * vehicle.Length) / 3) ||
                                    (i == 2 * ((master.bheight + 1) * vehicle.Length) / 3 + 1)))

                                    content += "\u0000";


                                else
                                    content += chara;

                            }
                            else
                            {
                                if ((i == 1 || i == master.bheight) && (
                                    (j == 2 * ((master.blength + 1) * vehicle.Length) / 3 + 2) ||
                                    (j == 2 * ((master.blength + 1) * vehicle.Length) / 3 + 1) ||
                                    (j == ((master.blength + 1) * vehicle.Length) / 3) ||
                                    (j == ((master.blength + 1) * vehicle.Length) / 3 - 1)))

                                    content += "\u0000";


                                else
                                    content += chara;
                            }
                        }
                        else
                        {
                            if (test)
                            {
                                if (vehicle.VehicleDirection == MMain.Direction.North
                                    && i == ((master.bheight + 1) * vehicle.Length) / 3 && (j <= 2 || j >= master.blength - 1))

                                    content += "\u0000";
                                    

                                else if (vehicle.VehicleDirection == MMain.Direction.South
                                    && i == 2 * ((master.bheight + 1) * vehicle.Length) / 3 && (j <= 2 || j >= master.blength - 1))

                                    content += "\u0000";


                                else
                                    content += chara;

                            }
                            else
                            {
                                if (vehicle.VehicleDirection == MMain.Direction.East &&(
                                    (j == 2 * ((master.blength + 1) * vehicle.Length) / 3 && (i == 1 || i == master.bheight)) ||
                                    (j == 2 * ((master.blength + 1) * vehicle.Length) / 3 + 1 && (i == 1 || i == master.bheight))))

                                    content += "\u0000";


                                else if (vehicle.VehicleDirection == MMain.Direction.West &&(
                                    (j == ((master.blength + 1) * vehicle.Length) / 3 && (i == 1 || i == master.bheight)) ||
                                    (j == ((master.blength + 1) * vehicle.Length) / 3 - 1 && (i == 1 || i == master.bheight))))

                                    content += "\u0000";


                                else
                                    content += chara;
                            }
                        }
                    }
                }

                if(i != (test ? (master.bheight + 1) * vehicle.Length + 1
                : master.bheight + 1) -1)
                    content += "\n";
            }
            Content = content;

        }

    }
}
