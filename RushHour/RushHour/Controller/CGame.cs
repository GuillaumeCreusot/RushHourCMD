using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class CGame
    {
        public MGame game;
        public CGame()
        {
            game = new MGame();
        }

        public void Launch()
        {
            CMainMenu mainMenu = new CMainMenu();
            int action = mainMenu.Control();
            if (action == 2) //quit game
            {
                game.gameEnded = true;
                Console.Clear(); //TODO better: display ASCII game over
            }
            else //launch game
            {
                if (action == 0) //new game
                {
                    game.grid = new MGrid(6, 6);
                    game.PlayerScore = 0;
                    //choose difficulty
                    CDifficultyMenu difficultyMenu = new CDifficultyMenu();
                    game.Difficulty = difficultyMenu.Control();
                }

                else if (action == 1) //load game
                {
                    //TODO : DEMANDER A l'USER QUEL JEU IL VEUT CHARGER, RECUPERER LA GRILLE ET LE SCORE ET RUN AVEC CES PARAMETRES
                    MGrid oldGrid = null; //TODO récuperer dans le fichier
                    int oldScore = 0;//TODO récuperer dans le fichier
                    MMain.Difficulty oldDiff = MMain.Difficulty.Easy;

                    game.grid = oldGrid;
                    game.PlayerScore = oldScore;
                    game.Difficulty = oldDiff;
                }
                Run(game.grid, game.PlayerScore);
            }

        }

        public void Run(MGrid grid, int score)
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            while (!game.gameEnded)
            {
                do //execute the game
                {
                    cki = Console.ReadKey();
                    
                }
                while (cki.Key != ConsoleKey.Escape);

                if (cki.Key == ConsoleKey.Escape)
                {
                    CEscapeMenu escapeMenu = new CEscapeMenu();
                    int escapeAction = escapeMenu.Control();
                    if (escapeAction == 0) //go back to game
                    {                        
                        Run(game.grid, game.PlayerScore);
                    }
                    else if (escapeAction == 1) //new game
                    {                        
                        Launch();
                    }
                    else //game over
                    {
                        game.gameEnded = true;
                        //TO DO : launch game over screen
                    }
                }
            }
        }
    }
}
