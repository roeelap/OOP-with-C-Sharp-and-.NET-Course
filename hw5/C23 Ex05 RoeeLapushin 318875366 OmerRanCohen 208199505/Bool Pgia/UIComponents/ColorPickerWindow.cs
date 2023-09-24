using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bool_Pgia
{
    public class ColorPickerWindow : Form
    {
        private readonly int m_CellMargin = 5;
        private readonly int m_WindowPadding = 10;
        private Color m_SelectedColor;

        public ColorPickerWindow(List<Color> i_AvaliableColors, int i_CellSize)
        {
            initComponents(i_AvaliableColors, i_CellSize);
        }

        public Color SelectedColor
        {
            get { return m_SelectedColor; }
        }

        private void initComponents(List<Color> i_AvaliableColors, int i_CellSize)
        {
            int numOfButtonsInRow = i_AvaliableColors.Count / 2;
            int windowWidth = (i_CellSize * numOfButtonsInRow) + (m_CellMargin * (numOfButtonsInRow - 1)) + (2 * m_WindowPadding);
            int windowHeight = (2 * (i_CellSize + m_CellMargin)) + (2 * m_WindowPadding);

            Text = "Pick A Color:";
            ClientSize = new Size(windowWidth, windowHeight);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            for (int i = 0; i < i_AvaliableColors.Count; i++)
            {
                Color color = i_AvaliableColors[i];
                Button colorPickerButton = new Button();
                colorPickerButton.BackColor = color;
                colorPickerButton.Width = i_CellSize;
                colorPickerButton.Height = colorPickerButton.Width;

                if (i < numOfButtonsInRow)
                {
                    colorPickerButton.Left = (i * (colorPickerButton.Width + m_CellMargin)) + m_WindowPadding;
                    colorPickerButton.Top = m_WindowPadding;
                }
                else
                {
                    colorPickerButton.Left = ((i - numOfButtonsInRow) * (colorPickerButton.Width + m_CellMargin)) + m_WindowPadding;
                    colorPickerButton.Top = m_WindowPadding + m_CellMargin + colorPickerButton.Height;
                }

                colorPickerButton.Click += colorPickerButton_Click;
                Controls.Add(colorPickerButton);
            }
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            m_SelectedColor = (sender as Button).BackColor;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
