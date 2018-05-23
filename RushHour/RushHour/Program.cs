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
            ///* TESTS WM + Grid + Vehicles*/
            //WidgetsManager wm = new WidgetsManager("wm", Console.LargestWindowWidth, Console.LargestWindowHeight);

            //MGrid grid = new MGrid(6, 6);

            ////Console.WriteLine(grid.IsValidPosition(0, 4, MMain.Direction.North, 3));

            //grid.AddVehicle(3, 3, MMain.Direction.North, 3);
            //grid.AddVehicle(0, 0, MMain.Direction.South, 2);

            //VGrid vgrid = new VGrid(12, 6, grid);

            //wm.AddWidgetsManager(vgrid, 0, 0);
            //wm.RefreshContentOnScreen();
            //vgrid.RefreshContentOnScreen();

            //vgrid.DeleteWidgetOnScreen("0");

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
            //MGrid grid = new MGrid(6, 6);

            //grid.AddVehicle(0, 0, MMain.Direction.East, 2);
            //grid.AddVehicle(3, 0, MMain.Direction.East, 2);
            //grid.AddVehicle(3, 3, MMain.Direction.North, 3);
            //grid.AddVehicle(5, 5, MMain.Direction.West, 3);

            //grid.SelectedItem = 1;

            //MGrid grid = new MGrid(StandardGrids.mediumGrid, 6, 6);

            //CGridControl yolo = new CGridControl(grid);
            //yolo.Control();

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
            //MVehicle truck = new MVehicle(game.game.grid, 0, 2, MMain.Direction.South, true);
            //truck.Pos[0] = 4;
            //truck.Pos[1] = 4;
            //vehicles.Add(truck);
            //game.game.grid.Vehicles = vehicles;
            //game.game.Save();

            //TEST GAME
            CGame game = new CGame();
            game.Launch();

            //Test ListSaves()
            //MGame game = new MGame();
            //game.Load();

            //test loading menu
            //CLoadMenu loadMenu = new CLoadMenu();
            //loadMenu.Control();
            //Console.ReadKey();

            //test color
            //WidgetsManager wm = new WidgetsManager("wm", Console.LargestWindowWidth, Console.LargestWindowHeight);
            //Label lb = new Label("lb", "Color", 1, 10);
            //lb.ColorPattern[0, 0] = ConsoleColor.Red;
            //lb.ColorPattern[0, 1] = ConsoleColor.Blue;
            //wm.AddWidget(lb, 0, 0);
            //wm.RefreshContentOnScreen();


            //test sub wiget manager
            //WidgetsManager main = new WidgetsManager("main", Console.LargestWindowWidth, Console.LargestWindowHeight);
            //Label lb = new Label("lb", "Main", 1, 10);
            //main.AddWidget(lb, 0, 0);

            //WidgetsManager sub = new WidgetsManager("sub", 10, 1, false);
            //main.AddWidgetManager(sub, 2, 0);

            //Label sublb = new Label("sublb", "Sub", 1, 10);
            //sub.AddWidget(sublb, 0, 0);

            //main.RefreshContentOnScreen();

            //Thread.Sleep(1000);

            //sub.RefreshContentOnScreen();

            Console.ReadKey();
        }
    }
}
