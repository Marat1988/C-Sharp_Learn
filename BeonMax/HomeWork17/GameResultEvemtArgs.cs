using System;

namespace HomeWork17
{
    public class GameResultEvemtArgs : EventArgs
    {
        public int questionPassed { get; }
        public int mistakesMade { get; }
        public bool isWin { get; }

        public GameResultEvemtArgs(int questionPassed, int mistakesMade, bool isWin)
        {
            this.questionPassed = questionPassed;
            this.mistakesMade = mistakesMade;
            this.isWin = isWin;
        }
    }
}
