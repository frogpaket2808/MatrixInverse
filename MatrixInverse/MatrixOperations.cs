using System;

namespace MatrixInverse
{
    public static class MatrixOperations
    {
        public static double Determinant(double[][] matrix)
        {
            double result = 0;
            if (matrix != null && matrix.Length > 0)
            {
                if (matrix.Length == 2)
                {
                    result = matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
                }
                else
                {
                    for (int i = 0; i < matrix.Length; i++)
                    {
                        result += matrix[0][i] * (double)Math.Pow(-1, 2 + i) * Determinant(CutMatrix(matrix, i));
                    }
                }
            }
            return result;
        }

        private static double[][] CutMatrix(double[][] matrix, int c)
        {
            int row = 0, col = 0;
            double[][] result = new double[matrix.Length - 1][];
            for (int i = 0; i < result.Length; i++)
                result[i] = new double[result.Length];

            for (int i = 1; i < matrix.Length; i++)
            {
                col = 0;
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (j != c)
                    {
                        result[row][col] = matrix[i][j];
                        col++;
                    }
                }
                row++;
            }
            return result;
        }
    }
}
