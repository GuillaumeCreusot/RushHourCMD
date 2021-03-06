﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Widget score
    /// </summary>
    class VScore : WidgetsManager
    {
        /// <summary>
        /// last score show
        /// </summary>
        private string lastScore;

        /// <summary>
        /// model grid to obtain score
        /// </summary>
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">widget's name</param>
        /// <param name="grid">model grid</param>
        public VScore(string name, MGrid grid) : base(name, InGameText.dimNb[1] * 3, InGameText.dimNb[0], false, true)
        {
            this.grid = grid;

            //instance label
            score1 = new Label("score1", InGameText.nb[0], InGameText.dimNb[0], InGameText.dimNb[1]);
            score2 = new Label("score2", InGameText.nb[0], InGameText.dimNb[0], InGameText.dimNb[1]);
            score3 = new Label("score3", InGameText.nb[0], InGameText.dimNb[0], InGameText.dimNb[1]);

            //add widget to widget manager
            AddWidget(score3, 0, 0);
            AddWidget(score2, 0, InGameText.dimNb[1]);
            AddWidget(score1, 0, InGameText.dimNb[1] * 2);

            //init lastscore
            lastScore = ScoreToString(grid.Score);
        }

        /// <summary>
        /// refresh content on screen
        /// </summary>
        /// <param name="delete">delete update (default = false)</param>
        public override void RefreshContentOnScreen(bool delete = false)
        {
            ///centaine
            if(grid.Score >= 100 && lastScore[0] != ScoreToString(grid.Score)[0])
            {
                score3.Text = InGameText.nb[Convert.ToInt32(ScoreToString(grid.Score)[0]) - 48];
                score2.Text = InGameText.nb[Convert.ToInt32(ScoreToString(grid.Score)[1]) - 48];
                score1.Text = InGameText.nb[Convert.ToInt32(ScoreToString(grid.Score)[2]) - 48];
            }

            //dizaine
            else if (grid.Score >= 10 && lastScore[1] != ScoreToString(grid.Score)[1])
            {
                score2.Text = InGameText.nb[Convert.ToInt32(ScoreToString(grid.Score)[1]) - 48];
                score1.Text = InGameText.nb[Convert.ToInt32(ScoreToString(grid.Score)[2]) - 48];
            }

            //unité
            else if (lastScore[2] != ScoreToString(grid.Score)[2])
            {
                score1.Text = InGameText.nb[Convert.ToInt32(ScoreToString(grid.Score)[2]) - 48];
            }

            
            base.RefreshContentOnScreen(delete);
        }

        /// <summary>
        /// Format score string
        /// </summary>
        /// <param name="score">score in number</param>
        /// <returns></returns>
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
