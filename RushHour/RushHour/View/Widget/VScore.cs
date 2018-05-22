using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VScore : WidgetsManager
    {
        private string lastScore;
        private MGrid grid;
        /// <summary>
        /// unité
        /// </summary>
        private Label score1;
        /// <summary>
        /// dizaine
        /// </summary>
        private Label score2;
        /// <summary>
        /// centaine
        /// </summary>
        private Label score3;

        public VScore(string name, MGrid grid) : base(name, InGameText.dimNb[1] * 3, InGameText.dimNb[0], false, true)
        {
            this.grid = grid;
            score1 = new Label("score1", InGameText.nb[0], InGameText.dimNb[0], InGameText.dimNb[1]);
            score2 = new Label("score2", InGameText.nb[0], InGameText.dimNb[0], InGameText.dimNb[1]);
            score3 = new Label("score3", InGameText.nb[0], InGameText.dimNb[0], InGameText.dimNb[1]);

            AddWidget(score3, 0, 0);
            AddWidget(score2, 0, InGameText.dimNb[1]);
            AddWidget(score1, 0, InGameText.dimNb[1] * 2);

            lastScore = ScoreToString(grid.Score);
        }

        public override void RefreshContentOnScreen(bool delete = false)
        {
            if(grid.Score >= 100 && lastScore[0] != ScoreToString(grid.Score)[0])
            {
                score3.Text = InGameText.nb[Convert.ToInt32(ScoreToString(grid.Score)[0]) - 48];
            }
            else if (grid.Score >= 10 && lastScore[1] != ScoreToString(grid.Score)[1])
            {
                score2.Text = InGameText.nb[Convert.ToInt32(ScoreToString(grid.Score)[1]) - 48];
            }
            else if (lastScore[2] != ScoreToString(grid.Score)[2])
            {
                score1.Text = InGameText.nb[Convert.ToInt32(ScoreToString(grid.Score)[2]) - 48];
            }

            base.RefreshContentOnScreen(delete);
        }

        public string ScoreToString(int score)
        {
            if(score >= 100)
            {
                return score.ToString();
            }
            else if(score >= 10)
            {
                return "0" + score.ToString();
            }
            else
            {
                return "00" + score.ToString();
            }
        }
    }
}
