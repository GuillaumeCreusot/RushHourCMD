using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RushHour
{
    class Program
    {
        static void Main(string[] args)
        {
            /* TESTS WM + Grid + Vehicles*/
            //WidgetsManager wm = new WidgetsManager("wm", Console.LargestWindowWidth, Console.LargestWindowHeight);

            //MGrid grid = new MGrid(6, 6);

            ////Console.WriteLine(grid.IsValidPosition(0, 4, MMain.Direction.North, 3));

            //grid.AddVehicle(0, 3, MMain.Direction.North, 2);

            //grid.GetVehicle(0).Move(MMain.Direction.South);



            //VGrid vgrid = new VGrid(12, 6, grid);

            //wm.AddWidget(vgrid, Console.LargestWindowHeight/2 - vgrid.height/2, (Console.LargestWindowWidth / 2) - (vgrid.length / 2));
            //wm.RefreshContentOnScreen();

            //Thread.Sleep(1000);


            //wm.RefreshContentOnScreen();




            /* TESTS MAIN MENU 
            VMainMenu menuTest = new VMainMenu();
            menuTest.Display();
            Console.ReadLine();*/

            /*TESTS GRILLE*/
            /*
            Console.WriteLine(vgrid.Content);

            */
            ///* TESTS MAIN MENU */
            //VMainMenu menuTest = new VMainMenu();
            //menuTest.Display();
            //Console.ReadLine();

            //test menu   
            /*     
            CMainMenu wesh = new CMainMenu();
            wesh.Control();
            Console.ReadLine();
            */



            //Test vehicle selection
            MGrid grid = new MGrid(6, 6);

            grid.AddVehicle(0, 0, MMain.Direction.East, 2);
            grid.AddVehicle(3, 0, MMain.Direction.East, 2);
            grid.AddVehicle(3, 3, MMain.Direction.North, 3);
            grid.AddVehicle(5, 5, MMain.Direction.West, 3);

            grid.SelectedItem = 1;

            //MGrid grid = new MGrid(StandardGrids.mediumGrid, 6, 6);

            CGridControl yolo = new CGridControl(grid);
            yolo.Control();

            /*Test escape menu
             CEscapeMenu wesh = new CEscapeMenu();
             wesh.Control();*/


           //Test escape menu
           // CEscapeMenu wesh = new CEscapeMenu();
           // wesh.Control();

            //TEST GAME
            //CGame game = new CGame();
            //game.Launch();
            //Console.ReadKey();

            //TEST SAVE
            //CGame game = new CGame();
            //game.game.PlayerScore = 0;
            //game.game.Grid = new MGrid(6, 6);
            //List<MVehicle> vehicles = new List<MVehicle>();
            //MVehicle truck = new MVehicle(game.game.grid, 0, 2, MMain.Direction.South, false);
            //truck.Pos[0] = 4;
            //truck.Pos[1] = 4;
            //vehicles.Add(truck);
            //game.game.grid.Vehicles = vehicles;
            //game.game.Save();
            //TEST GAME
            /*MGame game = new MGame();*/
            //CGame game = new CGame();
            //game.Launch();
            Console.ReadKey();
        }
    }
}
