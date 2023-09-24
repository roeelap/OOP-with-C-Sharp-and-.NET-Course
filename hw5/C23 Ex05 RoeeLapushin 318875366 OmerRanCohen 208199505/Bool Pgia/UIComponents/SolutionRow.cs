using System.Collections.Generic;
using System.Drawing;

namespace Bool_Pgia
{
    public class SolutionRow
    {
        private List<ColorButton> m_SolutionCells;

        public SolutionRow(int i_Left, int i_Top, int i_CellSize, int i_CellMargin, int i_GuessLength)
        {
            initComponents(i_Left, i_Top, i_CellSize, i_CellMargin, i_GuessLength);
        }

        public List<ColorButton> SolutionCells
        {
            get { return m_SolutionCells; }
        }

        public void RevealSolution(List<Color> solution)
        {
            for (int i = 0; i < solution.Count; i++)
            {
                m_SolutionCells[i].BackColor = solution[i];
            }
        }

        private void initComponents(int i_Left, int i_Top, int i_CellSize, int i_CellMargin, int i_GuessLength)
        {
            m_SolutionCells = new List<ColorButton>(i_GuessLength);

            for (int i = 0; i < i_GuessLength; i++)
            {
                int currSolutionBtnLeft = i_Left + (i * (i_CellSize + i_CellMargin));
                ColorButton solutionButton = new ColorButton(currSolutionBtnLeft, i_Top, i_CellSize, null);
                solutionButton.BackColor = Color.Black;
                m_SolutionCells.Add(solutionButton);
            }
        }
    }
}
