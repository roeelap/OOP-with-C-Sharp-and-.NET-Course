using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bool_Pgia
{
    public class GuessCountPickerWindow : Form
    {
        private readonly string m_ButtonMaxNumOfGuessesText = "Number of Chances: {0}";
        private readonly int m_ButtonMaxNumOfGuessesWidth = 200;
        private readonly int m_ButtonMaxNumOfGuessesHeight = 30;
        private readonly int m_ButtonStartWidth = 100;
        private readonly int m_ButtonMaxNumOfGuessesLeft = 20;
        private readonly int m_ButtonMaxNumOfGuessesTop = 15;
        private readonly int m_ButtonStartTop = 80;

        private int m_MaxNumOfGuesses;
        private int m_MinAllowedNumOfGuesses;
        private int m_MaxAllowedNumOfGuesses;
        private Button m_ButtonMaxNumOfGuesses;
        private Button m_ButtonStart;

        public GuessCountPickerWindow(int i_MinAllowedNumOfGuesses, int i_MaxAllowedNumOfGuesses)
        {
            m_MinAllowedNumOfGuesses = i_MinAllowedNumOfGuesses;
            m_MaxAllowedNumOfGuesses = i_MaxAllowedNumOfGuesses;
            m_MaxNumOfGuesses = m_MinAllowedNumOfGuesses;

            initComponents();
        }

        public int MaxNumOfGuesses
        {
            get { return m_MaxNumOfGuesses; }
        }

        private void initComponents()
        {
            // ButtonMaxNumOfGuesses
            m_ButtonMaxNumOfGuesses = new Button();
            m_ButtonMaxNumOfGuesses.Text = string.Format(m_ButtonMaxNumOfGuessesText, m_MaxNumOfGuesses);
            m_ButtonMaxNumOfGuesses.Location = new Point(m_ButtonMaxNumOfGuessesLeft, m_ButtonMaxNumOfGuessesTop);
            m_ButtonMaxNumOfGuesses.Size = new Size(m_ButtonMaxNumOfGuessesWidth, m_ButtonMaxNumOfGuessesHeight);
            m_ButtonMaxNumOfGuesses.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            m_ButtonMaxNumOfGuesses.Click += m_MaxNumOfGuessesButton_Click;
            Controls.Add(m_ButtonMaxNumOfGuesses);

            // ButtonStart
            m_ButtonStart = new Button();
            m_ButtonStart.Text = "Start";
            m_ButtonStart.Location = new Point(m_ButtonMaxNumOfGuesses.Right - m_ButtonStartWidth, m_ButtonStartTop);
            m_ButtonStart.Size = new Size(m_ButtonStartWidth, m_ButtonMaxNumOfGuessesHeight);
            m_ButtonStart.Click += m_ButtonStart_Click;
            Controls.Add(m_ButtonStart);

            // Window
            Text = "Bool Pgia";
            ClientSize = new Size((int)(m_ButtonMaxNumOfGuessesWidth * 1.2), m_ButtonMaxNumOfGuessesHeight * 4);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void m_MaxNumOfGuessesButton_Click(object sender, EventArgs e)
        {
            if (m_MaxNumOfGuesses < m_MaxAllowedNumOfGuesses)
            {
                m_MaxNumOfGuesses++;
            }
            else
            {
                m_MaxNumOfGuesses = m_MinAllowedNumOfGuesses;
            }

            m_ButtonMaxNumOfGuesses.Text = string.Format(m_ButtonMaxNumOfGuessesText, m_MaxNumOfGuesses);
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
