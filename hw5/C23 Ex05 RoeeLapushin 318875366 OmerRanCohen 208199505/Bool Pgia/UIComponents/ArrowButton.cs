using System.Windows.Forms;

namespace Bool_Pgia
{
    public class ArrowButton : Button
    {
        public ArrowButton(int i_Left, int i_Top, int i_CellSize)
        {
            initArrowButton(i_Left, i_Top, i_CellSize);
        }

        private void initArrowButton(int i_Left, int i_Top, int i_CellSize)
        {
            Width = i_CellSize;
            Height = i_CellSize / 2;
            Left = i_Left;
            Top = i_Top + (i_CellSize / 2) - (Height / 2);
            Text = "-->>";
            Enabled = false;
        }
    }
}