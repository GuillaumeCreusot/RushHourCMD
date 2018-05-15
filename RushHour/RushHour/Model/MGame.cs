using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class MGame
    {
<<<<<<< HEAD
        internal bool gameEnded;
        internal MGrid grid;
        internal MScore playerScore;
        internal MMain.Difficulty difficulty;
=======
        public bool GameEnded { get; set; }
        public MGrid Grid { get; set; }
        private MScore playerScore;
        private MMain.Difficulty difficulty;
>>>>>>> 986b3270d6fb5c6867f190d488fbb6194f89e9ce
        
        public MGame()
        {
            GameEnded = false;
        }

<<<<<<< HEAD
        public bool GameEnded
        {
            get
            {
                return gameEnded;
            }

            set
            {
                gameEnded = value;
            }
        }

        internal MGrid Grid
        {
            get
            {
                return grid;
            }

            set
            {
                grid = value;
            }
        }      
=======

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
>>>>>>> 986b3270d6fb5c6867f190d488fbb6194f89e9ce

        public void Save()
        {

        }

        public void Load()
        {

        }
    }
}
