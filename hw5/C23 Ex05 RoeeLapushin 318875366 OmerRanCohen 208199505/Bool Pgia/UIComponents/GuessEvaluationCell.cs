using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bool_Pgia
{
    public class GuessEvaluationCell
    {
        private readonly int m_Left;
        private readonly int m_Top;
        private readonly int m_CellSize;

        private List<Button> m_ResultButtons;

        public GuessEvaluationCell(int i_Left, int i_Top, int i_CellSize)
        {
            m_Left = i_Left;
            m_Top = i_Top;
            m_CellSize = i_CellSize;

            initResultButtons();
        }

        public List<Button> ResultButtons
        {
            get { return m_ResultButtons; }
        }

        public void UpdateResultButtons(List<Color> results)
        {
            for (int i = 0; i < results.Count; i++)
            {
                m_ResultButtons[i].BackColor = results[i];
            }
        }

        private void initResultButtons()
        {
            int resultBtnSizeInt = (int)(m_CellSize / 2.2);
            Size resultBtnSize = new Size(resultBtnSizeInt, resultBtnSizeInt);
            int resultBtnMargin = m_CellSize / 2;
            int rightButtonsLeft = m_Left + resultBtnMargin;
            int bottomButtonsTop = m_Top + resultBtnMargin;

            m_ResultButtons = new List<Button>(4);

            Button resultButton1 = new Button();
            resultButton1.Location = new Point(m_Left, m_Top);
            resultButton1.Size = resultBtnSize;
            resultButton1.Enabled = false;
            m_ResultButtons.Add(resultButton1);

            Button resultButton2 = new Button();
            resultButton2.Location = new Point(rightButtonsLeft, m_Top);
            resultButton2.Size = resultBtnSize;
            resultButton2.Enabled = false;
            m_ResultButtons.Add(resultButton2);

            Button resultButton3 = new Button();
            resultButton3.Location = new Point(m_Left, bottomButtonsTop);
            resultButton3.Size = resultBtnSize;
            resultButton3.Enabled = false;
            m_ResultButtons.Add(resultButton3);

            Button resultButton4 = new Button();
            resultButton4.Location = new Point(rightButtonsLeft, bottomButtonsTop);
            resultButton4.Size = resultBtnSize;
            resultButton4.Enabled = false;
            m_ResultButtons.Add(resultButton4);
        }
    }
}
