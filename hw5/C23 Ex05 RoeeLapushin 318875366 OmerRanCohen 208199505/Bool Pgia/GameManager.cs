using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bool_Pgia
{
    public class GameManager
    {
        private readonly int r_MinAllowedNumOfGuesses = 4;
        private readonly int r_MaxAllowedNumOfGuesses = 10;
        private readonly int r_SolutionLength = 4;

        private int m_MaxNumOfGuesses;
        private TurnHandler m_TurnHandler;

        private MainGameWindow m_MainGameWindow;

        public void Play()
        {
            int maxNumOfGuesses = askPlayerForMaximumNumOfGuesses();

            if (maxNumOfGuesses != -1) // if it is equal to -1 than the player pressed the X button
            {
                m_MaxNumOfGuesses = maxNumOfGuesses;
                m_TurnHandler = new TurnHandler(m_MaxNumOfGuesses, r_SolutionLength);
                m_MainGameWindow = new MainGameWindow(m_MaxNumOfGuesses, r_SolutionLength);
                m_MainGameWindow.UserGuessed += m_MainGameWindow_UserGuessed;
                m_MainGameWindow.ShowDialog();
            }
        }

        private int askPlayerForMaximumNumOfGuesses()
        {
            int maxNumOfGuesses = -1;

            GuessCountPickerWindow guessCountPickerWindow = new GuessCountPickerWindow(r_MinAllowedNumOfGuesses, r_MaxAllowedNumOfGuesses);

            if (guessCountPickerWindow.ShowDialog() == DialogResult.OK)
            {
                maxNumOfGuesses = guessCountPickerWindow.MaxNumOfGuesses;
            }

            return maxNumOfGuesses;
        }

        private bool isGuessContainsDuplicateColors(List<Color> i_InputGuess)
        {
            // Group colors in the input list by their value,
            // and check if any group has a count greater than 1, indicating duplicates.
            return i_InputGuess.GroupBy(c => c).Any(group => group.Count() > 1);
        }

        private void m_MainGameWindow_UserGuessed(List<Color> i_Guess)
        {
            if (isGuessContainsDuplicateColors(i_Guess))
            {
                MessageBox.Show("Invalid Guess! A valid guess cannot contain duplicate colors.", "Invalid Guess", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                m_TurnHandler.AddGuess(i_Guess);
                GuessEvaluation latestGuessEvaluation = m_TurnHandler.LatestTurn.GuessEvalution;
                m_MainGameWindow.ShowGuessEvaluation(m_TurnHandler.NumGuessesUntilNow - 1, latestGuessEvaluation.Evaluation);

                if (m_TurnHandler.IsLatestGuessEqualsSolution())
                {
                    MessageBox.Show("Congratulations! You've guessed the correct sequence!", "You Win", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_MainGameWindow.RevealSolution(m_TurnHandler.Solution);
                }
                else if (m_TurnHandler.NumGuessesUntilNow == m_MaxNumOfGuesses)
                {
                    MessageBox.Show("Unfortunately, you've exhausted all your guesses. Better luck next time!", "You Lose", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_MainGameWindow.RevealSolution(m_TurnHandler.Solution);
                }
                else
                {
                    m_MainGameWindow.EnableGuessRow(m_TurnHandler.NumGuessesUntilNow);
                }
            }
        }
    }
}
