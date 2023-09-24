using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bool_Pgia
{
    public delegate void UserGuessedDelegate(List<Color> guess);

    public class MainGameWindow : Form
    {
        private readonly int m_CellSize = 32;
        private readonly int m_CellMargin = 4;
        private readonly int m_WindowPadding = 10;
        private readonly int m_SolutionRowMarginFromFirstGuessRow = 25;

        private readonly int m_GuessLength;
        private readonly int m_MaxNumOfGuesses;
        private SolutionRow m_SolutionRow;
        private List<GuessRow> m_GuessRows;

        public MainGameWindow(int i_MaxNumOfGuesses, int i_GuessLength)
        {
            m_GuessLength = i_GuessLength;
            m_MaxNumOfGuesses = i_MaxNumOfGuesses;

            buildGameBoard();
        }

        public event UserGuessedDelegate UserGuessed;

        public void EnableGuessRow(int i_RowIndex)
        {
            if (i_RowIndex >= 0 && i_RowIndex < m_GuessRows.Count)
            {
                m_GuessRows[i_RowIndex].EnableColorButtons();
            }
        }

        public void RevealSolution(List<Color> i_Solution)
        {
            m_SolutionRow.RevealSolution(i_Solution);
        }

        public void ShowGuessEvaluation(int i_GuessRowIndex, List<Color> i_GuessEvaluation)
        {
            m_GuessRows[i_GuessRowIndex].GuessEvaluationCell.UpdateResultButtons(i_GuessEvaluation);
        }

        private void buildGameBoard()
        {
            Text = "Bool Pgia";
            int windowWidth = (m_CellSize * (m_GuessLength + 2)) + (m_CellMargin * (m_GuessLength + 1)) + (2 * m_WindowPadding);
            int windowHeight = (m_CellSize * (m_MaxNumOfGuesses + 1)) + (m_CellMargin * m_MaxNumOfGuesses) + m_SolutionRowMarginFromFirstGuessRow + (2 * m_WindowPadding);
            ClientSize = new Size(windowWidth, windowHeight);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            m_SolutionRow = new SolutionRow(m_WindowPadding, m_WindowPadding, m_CellSize, m_CellMargin, m_GuessLength);
            m_GuessRows = new List<GuessRow>(m_MaxNumOfGuesses);

            foreach (ColorButton solutionCell in m_SolutionRow.SolutionCells)
            {
                Controls.Add(solutionCell);
            }

            for (int i = 1; i <= m_MaxNumOfGuesses; i++)
            {
                int currGuessRowTop = (i * (m_CellSize + m_CellMargin)) + m_SolutionRowMarginFromFirstGuessRow;

                GuessRow guessRow = new GuessRow(m_WindowPadding, currGuessRowTop, m_CellSize, m_CellMargin, m_GuessLength);
                guessRow.ArrowButtonClicked += GuessRow_ArrowButtonClicked;
                m_GuessRows.Add(guessRow);

                foreach (ColorButton colorButton in guessRow.ColorButtons)
                {
                    Controls.Add(colorButton);
                }

                Controls.Add(guessRow.ArrowButton);

                foreach (Button resultButton in guessRow.GuessEvaluationCell.ResultButtons)
                {
                    Controls.Add(resultButton);
                }
            }

            EnableGuessRow(0);
        }

        protected virtual void OnUserGuessed(List<Color> i_Guess)
        {
            UserGuessed.Invoke(i_Guess);
        }

        private void GuessRow_ArrowButtonClicked(List<Color> i_Guess)
        {
            OnUserGuessed(i_Guess);
        }
    }
}
