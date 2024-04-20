using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    class MatrixMultiplier
    {
        private readonly int[,] matrixA;
        private readonly int[,] matrixB;
        private readonly int[,] resultMatrix;

        // Inicjalizacja macierzy A i B
        public MatrixMultiplier(int size)
        {
            matrixA = GenerateRandomMatrix(size);
            matrixB = GenerateRandomMatrix(size);
            resultMatrix = new int[size, size];
        }

        // Metoda do losowania wartości macierzy
        private int[,] GenerateRandomMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(1, 10); // Random numbers between 1 and 10
                }
            }
            return matrix;
        }

        // Mnożenie sekwencyjne
        public void MultiplySequential()
        {
            Multiply(matrixA, matrixB, resultMatrix);
        }

        // Mnożenie równoległe (ręczne) z użyciem klasy Threads
        public void MultiplyParallel(int numberOfThreads)
        {
            Thread[] threads = new Thread[numberOfThreads];
            int blockSize = resultMatrix.GetLength(0) / numberOfThreads;

            for (int i = 0; i < numberOfThreads; i++)
            {
                int start = blockSize * i;
                int end = (i == numberOfThreads - 1) ? resultMatrix.GetLength(0) : blockSize * (i + 1);
                if (end > resultMatrix.GetLength(0)) end = resultMatrix.GetLength(0);
                threads[i] = new Thread(() =>
                {
                    Multiply(matrixA, matrixB, resultMatrix, start, end);
                });

                threads[i].Start();
            }

            foreach (Thread thread in threads)
            {   
                thread.Join();
            }
        }

        // Mnożenie równoległe (zautomatyzowane) z użyciem biblioteki Parallel
        public void MultiplyParallel2(int numberOfThreads)
        {
            Parallel.For(0, numberOfThreads, i =>
            {
                int start = (resultMatrix.GetLength(0) / numberOfThreads) * i;
                int end = (i == numberOfThreads - 1) ? resultMatrix.GetLength(0) : (resultMatrix.GetLength(0) / numberOfThreads) * (i + 1);

                Multiply(matrixA, matrixB, resultMatrix, start, end);
            });
        }

        // Mnożenie macierzy
        private void Multiply(int[,] a, int[,] b, int[,] result, int startRow = 0, int endRow = -1)
        {
            int size = a.GetLength(0);
            if (endRow == -1) endRow = size;

            for (int i = startRow; i < endRow; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < size; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }
        }

        // Wyświetlanie danych wstępnych i wyników
        public void DisplayMatrices()
        {
            Console.WriteLine("Matrix A:");
            DisplayMatrix(matrixA);
            Console.WriteLine("Matrix B:");
            DisplayMatrix(matrixB);
            Console.WriteLine("Result Matrix:");
            DisplayMatrix(resultMatrix);
        }

        // Wyświetlanie samej macierzy wynikowej
        private void DisplayMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }

}
