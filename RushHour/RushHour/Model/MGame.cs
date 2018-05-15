using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class MGame
    {
        internal bool gameEnded;
        internal MGrid grid;
        internal MScore playerScore;
        internal MMain.Difficulty difficulty;
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

        public void Save()
        {

        }

        public void Load()
        {

        }
    }
}
