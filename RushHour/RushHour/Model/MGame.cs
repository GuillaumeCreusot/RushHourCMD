using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class MGame
    {
        bool gameEnded;

        public MGame()
        {
            GameEnded = false;
        }

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

        public void Launch()
        {            
            CMainMenu mainMenu = new CMainMenu();
            int action = mainMenu.Control();
            if (action == 0) //new game
            {
                MGrid newGrid = new MGrid(6,6);
                MScore score = new MScore();
                Run(newGrid, score);
            }

            else if (action == 1) //load game
            {
                //TODO : DEMANDER A l'USER QUEL JEU IL VEUT CHARGER, RECUPERER LA GRILLE ET LE SCORE ET RUN AVEC CES PARAMETRES
                MGrid oldGrid; //TODO récuperer dans le fichier
                MScore oldScore;//TODO récuperer dans le fichier
                //Run(oldGrid, oldScore);
            }

            else if (action == 2) //quit game
            {
                gameEnded = true;
                Console.Clear();
            }        
        }

        public void Run(MGrid grid, MScore score)
        {
            NotImplementedException excp = new NotImplementedException();
            throw excp;
            ConsoleKeyInfo cki = Console.ReadKey();
            while (!gameEnded)
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
