using System;
using System.Linq;
using System.Text;

namespace BoolPgiaa
{
    internal class GuessHandler
    {
        private readonly string r_Solution;

        private string[] m_Guesses;
        private string[] m_Results;
        private string m_LatestGuess;
        private int m_NumGuessesUntilNow;

        private string m_CorrectCharAtCorrectSpot = "V";
        private string m_CorrectCharAtIncorrectSpot = "X";

        internal GuessHandler(int i_MaximumNumOfGuesses, int i_SolutionLength)
        {
            r_Solution = generateRandomSolution(i_SolutionLength);
            m_Guesses = new string[i_MaximumNumOfGuesses];
            m_Results = new string[i_MaximumNumOfGuesses];
            m_NumGuessesUntilNow = 0;
        }

        internal string Solution
        {
            get => r_Solution;
        }

        internal string[] Guesses
        {
            get => m_Guesses;
        }

        internal string[] Results
        {
            get => m_Results;
        }

        internal int NumGuessesUntilNow
        {
            get => m_NumGuessesUntilNow;
        }

        internal bool IsLatestGuessEqualsSolution()
        {
            return r_Solution.Equals(m_LatestGuess);
        }

        internal void Guess(string i_InputGuess)
        {
            i_InputGuess = i_InputGuess.Replace(" ", string.Empty);
            m_Guesses[m_NumGuessesUntilNow] = i_InputGuess;
            m_Results[m_NumGuessesUntilNow] = evaluateGuess(i_InputGuess);
            m_LatestGuess = i_InputGuess;
            m_NumGuessesUntilNow++;
        }

        private static string generateRandomSolution(int i_SolutionLength)
        {
            Random randomLetterGenerator = new Random();
            StringBuilder solutionBuilder = new StringBuilder();

            while (solutionBuilder.Length < i_SolutionLength)
            {
                char randomChar = (char)('A' + randomLetterGenerator.Next('H' - 'A')); // picks a char between 'A' and 'H'

                if (!solutionBuilder.ToString().Contains(randomChar))
                {
                    solutionBuilder.Append(randomChar);
                }
            }

            return solutionBuilder.ToString();
        }

        private string evaluateGuess(string i_Guess)
        {
            StringBuilder evaluationBuilder = new StringBuilder();

            // check for correct letters in correct places (V)
            for (int i = 0; i < r_Solution.Length; i++)
            {
                if (r_Solution[i].Equals(i_Guess[i]))
                {
                    evaluationBuilder.Append(m_CorrectCharAtCorrectSpot);
                }
            }

            // check for correct letters in incorrect places (X)
            for (int i = 0; i < r_Solution.Length; i++)
            {
                if (r_Solution.Contains(i_Guess[i]) && !r_Solution[i].Equals(i_Guess[i]))
                {
                    evaluationBuilder.Append(m_CorrectCharAtIncorrectSpot);
                }
            }

            return evaluationBuilder.ToString();
        }
    }
}
