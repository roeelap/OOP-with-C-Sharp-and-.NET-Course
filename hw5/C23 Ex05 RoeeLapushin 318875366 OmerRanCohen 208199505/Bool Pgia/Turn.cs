using System.Collections.Generic;
using System.Drawing;

namespace Bool_Pgia
{
    internal class Turn
    {
        private static readonly List<Color> sr_AvailableColors = new List<Color> { Color.Purple, Color.Red, Color.LawnGreen, Color.Turquoise, Color.Blue, Color.Yellow, Color.Brown, Color.White };
        private List<Color> m_Guess;
        private GuessEvaluation m_GuessEvaluation;

        internal Turn(List<Color> i_Guess, List<Color> i_Solution)
        {
            m_Guess = i_Guess;
            m_GuessEvaluation = new GuessEvaluation(m_Guess, i_Solution);
        }

        internal static List<Color> AvailableColors
        {
            get { return sr_AvailableColors; }
        }

        internal GuessEvaluation GuessEvalution
        {
            get { return m_GuessEvaluation; }
        }
    }
}
