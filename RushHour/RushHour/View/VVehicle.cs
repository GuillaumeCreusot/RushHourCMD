using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Widget vehicle
    /// </summary>
    class VVehicle : Widget
    {

        /// <summary>
        /// state of player's vehicle
        /// </summary>
        public bool FlagCouleur {get; set; }

        /// <summary>
        /// model vehicle
        /// </summary>
        private MVehicle vehicle;
        public MVehicle Vehicle
        {
            get
            {
                return vehicle;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="veh">model vehicle</param>
        /// <param name="master">master grid</param>
        public VVehicle(MVehicle veh, VGrid master) : base(veh.IdVehicle.ToString()
            , (veh.VehicleDirection == MMain.Direction.North
                || veh.VehicleDirection == MMain.Direction.South)?(master.bheight + 1) * veh.Length + 1         
            : master.bheight + 1
            , !(veh.VehicleDirection == MMain.Direction.North
                || veh.VehicleDirection == MMain.Direction.South) ? (master.blength + 1) * veh.Length + 1       
            : master.blength + 1)
        {

            FlagCouleur = false;
            vehicle = veh;
            Master = master;

            //color of vehicle
            BasicColor = (veh.IsPlayer)?ConsoleColor.White:(ConsoleColor) (veh.IdVehicle % 14 + 1);

            //draw vehicle
            DrawVehicle();
        }
        
        public void DrawVehicle()
        {
            string content = "";
            char chara = (vehicle.IsSelected) ? (vehicle.IsMoving) ? '\u2591' : '\u2593' : '\u2588';
            //character different the vehicle is selected or not

            VGrid master = (VGrid)Master;

            //test de direction
            bool test = vehicle.VehicleDirection == MMain.Direction.North
                || vehicle.VehicleDirection == MMain.Direction.South;

            // i between 0 and the height of vehicle
            for (int i = 0; i < (test? (master.bheight + 1) * vehicle.Length +1
                : master.bheight + 1); i++)
            {
                // j between 0 and the length of vehicle
                for(int j = 0; j < (!test ? (master.blength + 1) * vehicle.Length +1
                : master.blength + 1); j++)
                {
                    // around the vehicle, we put the character (\u0000) which is consider transparent by widgetmanager
                    if( i == 0 || j == 0 
                        || i  == master.height - 1 || j == master.length - 1 
                        || (i % (master.bheight + 1) == 0 && j % (master.blength + 1) == 0)
                        || (i % (master.bheight + 1) == 0 && !(test && i != (master.bheight + 1) * vehicle.Length))
                        || (j % (master.blength + 1) == 0 && !(!test && j != (master.blength + 1) * vehicle.Length))
                        )
                    {
                        content += "\u0000";
                    }
                    //draw vehicule body
                    else
                    {
                        //for car
                        if (vehicle.Length == 2)
                        {
                            if (test)
                            {
                                // draw wheel
                                if ((j <= 2 || j >= master.blength - 1) && (
                                    (i == ((master.bheight + 1) * vehicle.Length) / 3) ||
                                    (i == 2 * ((master.bheight + 1) * vehicle.Length) / 3 + 1)))

                                    content += "\u0000";

                                
                                else
                                    content += chara;

                            }
                            else
                            {
                                //draw wheel
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
                        //draw truck
                        else
                        {
                            if (test)
                            {
                                // draw wheel
                                if (vehicle.VehicleDirection == MMain.Direction.North
                                    && i == ((master.bheight + 1) * vehicle.Length) / 3 && (j <= 2 || j >= master.blength - 1))

                                    content += "\u0000";
                                    
                                // draw wheel
                                else if (vehicle.VehicleDirection == MMain.Direction.South
                                    && i == 2 * ((master.bheight + 1) * vehicle.Length) / 3 && (j <= 2 || j >= master.blength - 1))

                                    content += "\u0000";


                                else
                                    content += chara;

                            }
                            else
                            {
                                //draw wheel
                                if (vehicle.VehicleDirection == MMain.Direction.East &&(
                                    (j == 2 * ((master.blength + 1) * vehicle.Length) / 3 && (i == 1 || i == master.bheight)) ||
                                    (j == 2 * ((master.blength + 1) * vehicle.Length) / 3 + 1 && (i == 1 || i == master.bheight))))

                                    content += "\u0000";

                                //draw wheel
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

            //color vehicle player beacon
            if (vehicle.IsPlayer)
            {
                //state 1
                if (test)
                {
                    ColorPattern[((master.bheight + 1) * vehicle.Length), (master.blength + 1) / 2 + 1] = (FlagCouleur) ? ConsoleColor.Blue : ConsoleColor.Red;
                    ColorPattern[((master.bheight + 1) * vehicle.Length), (master.blength + 1) / 2 - 1] = (!FlagCouleur) ? ConsoleColor.Blue : ConsoleColor.Red;
                    FlagCouleur = !FlagCouleur;
                }
                //state 2
                else
                {
                    ColorPattern[((master.bheight + 1)/ 2 + 2), ((master.blength + 1) * vehicle.Length) / 2] = (FlagCouleur) ? ConsoleColor.Blue : ConsoleColor.Red;
                    ColorPattern[((master.bheight + 1)/ 2 - 1), ((master.blength + 1) * vehicle.Length) / 2] = (!FlagCouleur) ? ConsoleColor.Blue : ConsoleColor.Red;
                    FlagCouleur = !FlagCouleur;
                }
                
            }
        }

    }
}
