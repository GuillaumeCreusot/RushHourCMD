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
            Console.Clear();

            CMainMenu mainMenu = new CMainMenu();
            int action = mainMenu.Control();
            if (action == 2) //quit game
            {
                game.gameEnded = true;
                Console.Clear();
                CGameOver gameOver = new CGameOver();
            }
            else //launch game
            {
                Console.Clear();

                if (action == 0) //new game
                {
                    game.grid = new MGrid(6, 6);
                    game.PlayerScore = 0;
                    //choose difficulty
                    CDifficultyMenu difficultyMenu = new CDifficultyMenu();
                    game.Difficulty = difficultyMenu.Control();

                    if (game.difficulty == 0)
                        game.grid = new MGrid(StandardGrids.easyGrid, 6, 6);
                    else if (game.difficulty == MMain.Difficulty.Medium)
                        game.grid = new MGrid(StandardGrids.mediumGrid, 6, 6);
                    else if (game.difficulty == MMain.Difficulty.Hard)
                        game.grid = new MGrid(StandardGrids.hardGrid, 6, 6);
                    else
                        game.grid = new MGrid(StandardGrids.easyGrid, 6, 6);
                }

                else if (action == 1) //load game
                {
                    CLoadMenu loadMenu = new CLoadMenu();
                    int saveToLoad = loadMenu.Control();
                    //find save to load
                    game.Load(saveToLoad);
                }
                Run(game.grid, game.PlayerScore);
            }

        }

        public void Run(MGrid grid, int score)
        {
            Console.Clear();

            CGridControl gridGontrol = new CGridControl(game.grid);

            while (!game.gameEnded)
            {
                int result = gridGontrol.Control();

                if (result == 1)
                {
                    Console.Clear();

                    CEscapeMenu escapeMenu = new CEscapeMenu();
                    int escapeAction = escapeMenu.Control();
                    if (escapeAction == 0) //go back to game
                    {
                        continue;
                    }
                    else if (escapeAction == 1) //save and continue
                    {
                        game.Save();
                        continue;
                    }
                    else if (escapeAction == 2) //save and quit
                    {
                        game.Save();
                        CGameOver gameOver = new CGameOver();
                        game.gameEnded = true;
                    }
                    else if (escapeAction == 3) //new game
                    {                        
                        Launch();
                    }
                    else //game over
                    {
                        CGameOver gameOver = new CGameOver();
                        game.gameEnded = true;
                    }
                }
            }
        }
    }
}
