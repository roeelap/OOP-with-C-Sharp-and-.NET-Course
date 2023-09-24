using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Bool_Pgia
{
    internal class TurnHandler
    {
        private readonly List<Color> r_Solution;

        private List<Turn> m_Turns;
        private List<Color> m_LatestGuess;
        private int m_NumGuessesUntilNow;

        internal TurnHandler(int i_MaximumNumOfGuesses, int i_SolutionLength)
        {
            r_Solution = generateRandomSolution(i_SolutionLength);
            m_Turns = new List<Turn>(i_MaximumNumOfGuesses);
            m_NumGuessesUntilNow = 0;
        }

        internal List<Color> Solution
        {
            get { return r_Solution; }
        }

        internal int NumGuessesUntilNow
        {
            get => m_NumGuessesUntilNow;
        }

        internal Turn LatestTurn
        {
            get { return m_Turns.Last(); }
        }

        internal bool IsLatestGuessEqualsSolution()
        {
            bool isEqual = true;

            for (int i = 0; i < r_Solution.Count; i++)
            {
                if (!r_Solution[i].Equals(m_LatestGuess[i]))
                {
                    isEqual = false;
                    break;
                }
            }

            return isEqual;
        }

        internal void AddGuess(List<Color> i_InputGuess)
        {
            m_Turns.Add(new Turn(i_InputGuess, r_Solution));
            m_LatestGuess = i_InputGuess;
            m_NumGuessesUntilNow++;
        }

        private static List<Color> generateRandomSolution(int i_SolutionLength)
        {
            Random random = new Random();
            HashSet<Color> solution = new HashSet<Color>();

            while (solution.Count < i_SolutionLength)
            {
                int randomIndex = random.Next(Turn.AvailableColors.Count);
                Color randomColor = Turn.AvailableColors[randomIndex];
                solution.Add(randomColor);
            }

            return solution.ToList();
        }
    }
}
