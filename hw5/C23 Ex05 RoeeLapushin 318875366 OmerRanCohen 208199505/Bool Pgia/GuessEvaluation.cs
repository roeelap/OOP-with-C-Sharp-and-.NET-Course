using System.Collections.Generic;
using System.Drawing;

namespace Bool_Pgia
{
    internal class GuessEvaluation
    {
        private readonly List<Color> m_Evaluation;

        internal GuessEvaluation(List<Color> i_Guess, List<Color> i_Solution)
        {
            List<Color> evaluation = new List<Color>();

            // check for correct letters in correct places (Black)
            for (int i = 0; i < i_Solution.Count; i++)
            {
                if (i_Solution[i].Equals(i_Guess[i]))
                {
                    evaluation.Add(Color.Black);
                }
            }

            // check for correct letters in incorrect places (Yellow)
            for (int i = 0; i < i_Solution.Count; i++)
            {
                if (i_Solution.Contains(i_Guess[i]) && !i_Solution[i].Equals(i_Guess[i]))
                {
                    evaluation.Add(Color.Yellow);
                }
            }

            m_Evaluation = evaluation;
        }

        internal List<Color> Evaluation
        {
            get { return m_Evaluation; }
        }
    }
}
