using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bool_Pgia
{
    public delegate void ColorChangedDelegate();

    public class ColorButton : Button
    {
        private bool m_IsPicked = false;
        private List<Color> m_AvaliableColors;

        public ColorButton(int i_Left, int i_Top, int i_Size, List<Color> i_AvaliableColors)
        {
            Left = i_Left;
            Top = i_Top;
            Width = i_Size;
            Height = i_Size;
            Enabled = false;
            m_AvaliableColors = i_AvaliableColors;
            Click += OnClick;
        }

        public event ColorChangedDelegate ColorChanged;

        public bool IsPicked
        {
            get { return m_IsPicked; }
        }

        protected virtual void OnClick(object sender, EventArgs e)
        {
            if (m_AvaliableColors != null)
            {
                ColorPickerWindow colorPicker = new ColorPickerWindow(m_AvaliableColors, Width);
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    m_IsPicked = true;
                    BackColor = colorPicker.SelectedColor;
                    ColorChanged.Invoke();
                }
            }
        }
    }
}
