using System;
using System.IO;
using System.Windows.Forms;


namespace MatrixInverse
{
    public partial class MatrixInverse : Form
    {
        double[][] matrix;
        double[][] result;
        int iterations;
        public MatrixInverse()
        {
            InitializeComponent();
        }

        private void CalculationButton_Click(object sender, EventArgs e)
        {
            ReadMatrix();

            if (matrix != null)
            {
                if (MatrixOperations.Determinant(matrix) == 0)
                {
                    MessageBox.Show("Визначник матриці дорівнює нулю. Обертання не є можливим.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int iterations = 0;
                    double elapsedTime = 0;
                    if (JordanGaussButton.Checked)
                    {
                        result = InverseMethods.JordanGaussMethod(matrix, ref iterations, out elapsedTime);
                    }
                    else if (BorderingButton.Checked)
                    {
                        result = InverseMethods.BorderingMethod(matrix, ref iterations, out elapsedTime);
                    }
                    else
                    {
                        MessageBox.Show("Ви не обрали метод обертання.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (result != null && richTextBox1 != null)
                    {
                        TextLable.Text = $"Кількість ітерацій: {iterations}\nЧас обчислення: {elapsedTime:F8} сек.\n";
                        UtilityMethods.WriteMatrix(MatrixPanel, result);
                    }
                }
            }
        }


        private void ReadMatrix()
        {
            matrix = UtilityMethods.ReadMatrix(MatrixPanel);
        }


        private void MatrixDimension_ValueChanged(object sender, EventArgs e)
        {
            MatrixDimension.ReadOnly = true;
            MatrixDimension.Maximum = 8;
            MatrixDimension.Minimum = 2;

            int dimension = (int)MatrixDimension.Value;

            int cellSize = 60;
            int spacing = 2;

            if (MatrixPanel == null)
            {
                MatrixPanel = new TableLayoutPanel();
                MatrixPanel.Dock = DockStyle.Fill;
                this.Controls.Add(MatrixPanel);
            }

            UIHelpers.CreateTableLayoutPanel(MatrixPanel, dimension, cellSize, spacing);
        }

        private void RandomMatrixButton_Click(object sender, EventArgs e)
        {
            UtilityMethods.GenerateRandomMatrix(MatrixPanel);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            UIHelpers.ClearTableCells(MatrixPanel);
        }


        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            string method = "";
            if (result != null && matrix != null)
            {
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.Title = "Зберегти дані";
                    saveFileDialog1.Filter = "Текстові файли (*.txt)|*.txt";
                    saveFileDialog1.FileName = "results.txt";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog1.FileName;

                        try
                        {
                            using (StreamWriter writer = new StreamWriter(filePath))
                            {
                                if (JordanGaussButton.Checked)
                                {
                                    method = "Жордана-Гауса";
                                }
                                if (BorderingButton.Checked)
                                {
                                    method = "Окаймлення";
                                }
                                writer.WriteLine($"Метод: {method}\n");
                                writer.WriteLine("Початкова матриця:");
                                UtilityMethods.SaveToFile(matrix, writer);

                                writer.WriteLine("\nОбернена матриця:");

                                UtilityMethods.SaveToFile(result, writer);
                            }

                            MessageBox.Show("Дані успішно збережено у файл.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не вдалося зберегти дані у файл: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Матриця або результат порожні. Обернення не виконано.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}