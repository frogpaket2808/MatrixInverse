using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MatrixInverse
{
    public static class UtilityMethods
    {
        public static double[][] ReadMatrix(TableLayoutPanel MatrixPanel)
        {
            List<List<double>> matrix = new List<List<double>>();
            foreach (Control control in MatrixPanel.Controls)
            {
                if (control is TextBox textBox)
                {
                    double value;
                    if (double.TryParse(textBox.Text, out value))
                    {
                        if (ValidateDoubleFormat(textBox.Text))
                        {
                            if (value >= -100 && value <= 100)
                            {
                                if (matrix.Count == 0 || matrix[matrix.Count - 1].Count == MatrixPanel.ColumnCount)
                                {
                                    matrix.Add(new List<double>());
                                }
                                matrix[matrix.Count - 1].Add(value);
                            }
                            else
                            {
                                MessageBox.Show("Ви ввели значення, що не є в проміжку між -100 до 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Кількість знаків після коми не може перевищувати 10.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ви ввели нечислове значення.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }

            double[][] newMatrix = new double[matrix.Count][];
            for (int i = 0; i < matrix.Count; i++)
            {
                newMatrix[i] = matrix[i].ToArray();
            }
            return newMatrix;
        }

        public static bool ValidateDoubleFormat(string val)
        {
            string[] parts = val.Split(',');

            string doublePart = parts.Length > 1 ? parts[1] : "";

            return doublePart.Length <= 10;
        }

        public static void GenerateRandomMatrix(TableLayoutPanel MatrixPanel)
        {
            if (MatrixPanel == null || MatrixPanel.Controls == null)
            {
                MessageBox.Show("Матриця не ініціалізована.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Random r = new Random();

            foreach (Control control in MatrixPanel.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = (r.Next(1, 100)).ToString();
                }
            }

            MatrixPanel.Refresh();
        }

        public static void WriteMatrix(TableLayoutPanel MatrixPanel, double[][] matrix)
        {
            int dimension = matrix.Length;
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    TextBox textBox = (TextBox)MatrixPanel.GetControlFromPosition(j, i);
                    if (textBox != null)
                    {
                        textBox.Text = matrix[i][j].ToString("F10");

                    }
                }
            }
        }


        public static void SaveToFile(double[][] matrix, StreamWriter writer)
        {
            int dimension = matrix.Length;
            for (int i = 0; i < dimension; i++)
            {
                string line = string.Join(" ", matrix[i].Select(x => Math.Round(x, 3)));
                writer.WriteLine(line);
            }
        }
    }
}

