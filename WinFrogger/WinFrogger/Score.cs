using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFrogger
{
    class Score
    {
        // Variabeln
        int score;
        string fileName;

        // Properties
        public int CurrentScore
        {
            get { return score; }
            set { if (value >= 0) score = value; }
        }

        // Konstruktor
        public Score(string fName)
        {
            fileName = fName;
        }

        public void SetEndScore(string playerName)
        {
        }

        public string[] GetScores()
        {
            return new string[0];
        }

        public int GetScore(string playerName)
        {
            return 0;
        }

        public string GetHighScore()
        {
            return "";
        }

    }
}
