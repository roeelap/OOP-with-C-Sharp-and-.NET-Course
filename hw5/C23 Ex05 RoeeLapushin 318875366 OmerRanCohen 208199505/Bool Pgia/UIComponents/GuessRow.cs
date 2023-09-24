using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Bool_Pgia
{
    public delegate void ArrowButtonClickedDelegate(List<Color> guess);

    public class GuessRow
    {
        private readonly int m_Left;
        private readonly int m_Top;
        private readonly int m_GuessLength;
        private readonly int m_CellSize;
        private readonly int m_CellMargin;

        private List<ColorButton> m_ColorButtons;
        private ArrowButton m_ArrowButton;
        private GuessEvaluationCell m_GuessEvaluationCell;

        public GuessRow(int i_Left, int i_Top, int i_CellSize, int i_CellMargin, int i_GuessLength)
        {
            m_GuessLength = i_GuessLength;
            m_Left = i_Left;
            m_Top = i_Top;
            m_CellSize = i_CellSize;
            m_CellMargin = i_CellMargin;

            initComponents();
        }

        public event ArrowButtonClickedDelegate ArrowButtonClicked;

        public List<ColorButton> ColorButtons
        {
            get { return m_ColorButtons; }
        }

        public ArrowButton ArrowButton
        {
            get { return m_ArrowButton; }
        }

        public GuessEvaluationCell GuessEvaluationCell
        {
            get { return m_GuessEvaluationCell; }
        }

        public void EnableColorButtons()
        {
            foreach (ColorButton colorButton in m_ColorButtons)
            {
                colorButton.Enabled = true;
            }
        }

        private void initComponents()
        {
            int guessEvaluationCellLeft = m_Left + ((m_GuessLength + 1) * (m_CellSize + m_CellMargin));
            int arrowBtnLeft = m_Left + (m_GuessLength * (m_CellSize + m_CellMargin));

            m_ArrowButton = new ArrowButton(arrowBtnLeft, m_Top, m_CellSize);
            m_ArrowButton.Click += m_ArrowButton_Click;

            m_GuessEvaluationCell = new GuessEvaluationCell(guessEvaluationCellLeft, m_Top, m_CellSize);

            initColorButtons();
        }

        private void initColorButtons()
        {
            m_ColorButtons = new List<ColorButton>(m_GuessLength);

            for (int i = 0; i < m_GuessLength; i++)
            {
                int currColorBtnLeft = m_Left + (i * (m_CellSize + m_CellMargin));
                ColorButton colorButton = new ColorButton(currColorBtnLeft, m_Top, m_CellSize, Turn.AvailableColors);
                colorButton.ColorChanged += m_ColorButton_Click;
                m_ColorButtons.Add(colorButton);
            }
        }

        private void m_ColorButton_Click()
        {
            bool isAllColorButtonsPicked = true;
            foreach (ColorButton colorButton in m_ColorButtons)
            {
                if (colorButton.IsPicked == false)
                {
                    isAllColorButtonsPicked = false;
                    break;
                }
            }

            m_ArrowButton.Enabled = isAllColorButtonsPicked;
        }

        protected virtual void m_ArrowButton_Click(object sender, EventArgs e)
        {
            ArrowButtonClicked?.Invoke(getGuess());
            m_ArrowButton.Enabled = false;
        }

        private List<Color> getGuess()
        {
            List<Color> guess = new List<Color>();

            foreach (ColorButton colorButton in m_ColorButtons)
            {
                if (colorButton.BackColor != null)
                {
                    guess.Add(colorButton.BackColor);
                }
            }

            return guess;
        }
    }
}
