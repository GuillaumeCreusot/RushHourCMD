﻿using System;
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
            
            MGrid grid = new MGrid(6, 6);

            //Console.WriteLine(grid.IsValidPosition(0, 4, MMain.Direction.North, 3));

            MVehicle v1 = new MVehicle(grid, 0, 3, MMain.Direction.North, false);
            grid.Vehicles.Add(v1);
            v1.Pos = new int[2] { 0, 3 };

            v1.Move(MMain.Direction.South);



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
            /*MGrid grid = new MGrid(6, 6);

            

            MVehicle v1 = new MVehicle(grid, 0, 2, MMain.Direction.East, 0, 0, false);
            grid.Vehicles.Add(v1);

            MVehicle v2 = new MVehicle(grid, 0, 3, MMain.Direction.North, 3, 3, false);
            grid.Vehicles.Add(v2);

            MVehicle v3 = new MVehicle(grid, 0, 3, MMain.Direction.West, 5, 5, false);
            grid.Vehicles.Add(v3);

            grid.SelectedItem = 1;*/

<<<<<<< HEAD
            //MGrid grid = new MGrid(StandardGrids.mediumGrid, 6, 6);

            //CGridControl yolo = new CGridControl(grid);
            //yolo.Control();
=======
            //MGrid grid = new MGrid(StandardGrids.hardGrid, 6, 6);

            /*CGridControl yolo = new CGridControl(grid);
            yolo.Control();
>>>>>>> ae24a9ecaa11ccf707e6fcaf16d5ccc198cbd223

           /Test escape menu
            CEscapeMenu wesh = new CEscapeMenu();
            wesh.Control();*/
               
            //TEST GAME
<<<<<<< HEAD
            /*MGame game = new MGame();
            game.Launch();*/
=======
            CGame game = new CGame();
            game.Launch();
>>>>>>> ae24a9ecaa11ccf707e6fcaf16d5ccc198cbd223
            Console.ReadKey();
        }
    }
}
