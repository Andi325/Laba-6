using System;

namespace Завдання_2
{
    class MathOperations
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    
        public static int[] Add(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                throw new ArgumentException("Arrays must have the same length");
            }

            int[] result = new int[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i] + arr2[i];
            }

            return result;
        }
    
        public static int[,] Add(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new ArgumentException("Matrices must have the same dimensions");
            }

            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);

            int[,] result = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }
    }
}

