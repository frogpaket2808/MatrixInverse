using System.Drawing;
using System.Windows.Forms;

namespace MatrixInverse
{
    public static class UIHelpers
    {
        public static void CreateTableLayoutPanel(TableLayoutPanel panel, int dimension, int cellSize, int spacing)
        {
            panel.Controls.Clear();
            panel.RowStyles.Clear();
            panel.ColumnStyles.Clear();
            panel.RowCount = dimension;
            panel.ColumnCount = dimension;
            panel.Padding = new Padding(spacing);
            panel.Margin = new Padding(0);
            panel.BorderStyle = BorderStyle.None;
            panel.BackColor = Color.Transparent;

            for (int i = 0; i < dimension; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellSize));
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, cellSize));
            }

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Width = cellSize;
                    textBox.Height = cellSize;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.Font = new Font("Consolas", 13);
                    textBox.Margin = new Padding(5);
                    textBox.Padding = new Padding(0);
                    textBox.BackColor = Color.White;
                    panel.Controls.Add(textBox, j, i);
                }
            }

            int tableWidth = (cellSize + spacing) * dimension + panel.Margin.Horizontal;
            int tableHeight = (cellSize + spacing) * dimension + panel.Margin.Vertical;
            panel.Size = new Size(tableWidth, tableHeight);
        }


        public static void ClearTableCells(TableLayoutPanel MatrixPanel)
        {
            foreach (Control control in MatrixPanel.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear(); 
                }
            }
        }
    }
}


