using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class MScore
    {
        private int playerScore;

        public MScore()
        {
            PlayerScore = 0;
        }

        public int PlayerScore
        {
            get
            {
                return playerScore;
            }

            set
            {
                playerScore = value;
            }
        }
    }
}
