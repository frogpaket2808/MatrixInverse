using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MatrixInverse
{
    internal class InverseMethods
    {
        public static double[][] BorderingMethod(double[][] matrix, ref int iterations, out double elapsedTime)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double[][] inversedMatrix = new double[matrix.Length][];
            iterations = 0;
            int innerIterations = 0;

            for (int i = 0; i < matrix.Length; i++)
                inversedMatrix[i] = new double[matrix.Length];

            inversedMatrix[0][0] = 1.0 / matrix[0][0];

            for (int k = 1; k < matrix.Length; k++)
            {
                iterations++;
                double[] u = new double[k];
                double[] v = new double[k];

                for (int i = 0; i < k; i++)
                {
                    innerIterations++;
                    u[i] = matrix[i][k];
                    v[i] = matrix[k][i];
                }

                double ann = matrix[k][k];

                double[] q = new double[k];
                double[] r = new double[k];

                for (int i = 0; i < k; i++)
                {
                    innerIterations++;
                    double dotProduct1 = 0.0;
                    double dotProduct2 = 0.0;
                    for (int j = 0; j < k; j++)
                    {
                        innerIterations++;
                        dotProduct1 -= inversedMatrix[i][j] * u[j];
                        dotProduct2 -= inversedMatrix[j][i] * v[j];
                    }
                    q[i] = dotProduct1;
                    r[i] = dotProduct2;
                }

                double alpha = ann;

                for (int i = 0; i < k; i++)
                {
                    innerIterations++;
                    alpha += r[i] * u[i];
                }

                if (Math.Abs(alpha) < 1e-10)
                {
                    alpha = 1e-10;
                }

                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        innerIterations++;
                        inversedMatrix[i][j] += (q[i] * r[j]) / alpha;
                    }
                    inversedMatrix[k][i] = r[i] / alpha;
                    inversedMatrix[i][k] = q[i] / alpha;
                }
                inversedMatrix[k][k] = 1.0 / alpha;
            }
            stopwatch.Stop();
            elapsedTime = Math.Round(stopwatch.Elapsed.TotalSeconds, 15);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            iterations += innerIterations;
            return inversedMatrix;
        }

        public static double[][] JordanGaussMethod(double[][] matrix, ref int iterations, out double elapsedTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            iterations = 0;

            double[][] inversedMatrix = new double[matrix.Length][];
            double[][] workingMatrix = new double[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                inversedMatrix[i] = new double[matrix.Length];
                workingMatrix[i] = new double[matrix.Length];
                inversedMatrix[i][i] = 1;
                Array.Copy(matrix[i], workingMatrix[i], matrix.Length);
            }

            for (int i = 0; i < workingMatrix.Length; i++)
            {
                if (workingMatrix[i][i] == 0)
                {
                    int swapRow = -1;
                    for (int k = i + 1; k < workingMatrix.Length; k++)
                    {
                        iterations++;
                        if (workingMatrix[k][i] != 0)
                        {
                            swapRow = k;
                            break;
                        }
                    }

                    if (swapRow != -1)
                    {
                        double[] tempRow = workingMatrix[i];
                        workingMatrix[i] = workingMatrix[swapRow];
                        workingMatrix[swapRow] = tempRow;

                        double[] tempInverseRow = inversedMatrix[i];
                        inversedMatrix[i] = inversedMatrix[swapRow];
                        inversedMatrix[swapRow] = tempInverseRow;
                    }
                    else
                    {
                        MessageBox.Show("Матриця є сингулярною. Обертання не є можливим.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        elapsedTime = 0;
                        return null;
                    }
                }

                double temp = workingMatrix[i][i];
                for (int j = 0; j < workingMatrix.Length; j++)
                {
                    iterations++;
                    workingMatrix[i][j] /= temp;
                    inversedMatrix[i][j] /= temp;
                }

                for (int k = 0; k < workingMatrix.Length; k++)
                {
                    if (k != i)
                    {
     
                        temp = workingMatrix[k][i];
                        for (int j = 0; j < workingMatrix.Length; j++)
                        {
                            iterations++;
                            workingMatrix[k][j] -= workingMatrix[i][j] * temp;
                            inversedMatrix[k][j] -= inversedMatrix[i][j] * temp;
                        }
                    }
                }
            }

            stopwatch.Stop();
            elapsedTime = Math.Round(stopwatch.Elapsed.TotalSeconds, 15);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return inversedMatrix;
        }
    }
}

