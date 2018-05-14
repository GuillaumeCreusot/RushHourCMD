using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class MGame
    {
        public bool GameEnded { get; set; }
        public MGrid Grid { get; set; }
        private MScore playerScore;
        private MMain.Difficulty difficulty;
        
        public MGame()
        {
            GameEnded = false;
        }


        public void Launch()
        {            
            CMainMenu mainMenu = new CMainMenu();
            int action = mainMenu.Control();
            if (action == 2) //quit game
            {
                GameEnded = true;
                Console.Clear(); //TODO better: display ASCII game over
            }
            else //launch game
            {
                if (action == 0) //new game
                {
                    Grid = new MGrid(6, 6);
                    playerScore = new MScore();
                    //choose difficulty
                    CDifficultyMenu difficultyMenu = new CDifficultyMenu();
                    difficulty = difficultyMenu.Control();
                }

                else if (action == 1) //load game
                {
                    //TODO : DEMANDER A l'USER QUEL JEU IL VEUT CHARGER, RECUPERER LA GRILLE ET LE SCORE ET RUN AVEC CES PARAMETRES
                    MGrid oldGrid = null; //TODO récuperer dans le fichier
                    MScore oldScore = null;//TODO récuperer dans le fichier
                    MMain.Difficulty oldDiff= MMain.Difficulty.Easy;

                    Grid = oldGrid;
                    playerScore = oldScore;
                    difficulty = oldDiff;
                }
                Run(Grid, playerScore);
            }
  
        }

        public void Run(MGrid grid, MScore score)
        {
            throw new NotImplementedException();
            ConsoleKeyInfo cki = Console.ReadKey();

            while (!GameEnded)
            {
                do
                {
                    cki = Console.ReadKey();
                    //execute the game
                }
                while (cki.Key != ConsoleKey.Escape);

                if (cki.Key == ConsoleKey.Escape)
                {
                    CEscapeMenu escapeMenu = new CEscapeMenu();
                    escapeMenu.Control();
                }
            }
        }

        public void Save()
        {

        }

        public void Load()
        {

        }
    }
}
