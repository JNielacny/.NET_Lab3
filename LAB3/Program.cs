using System;
using System.Diagnostics;
using System.Threading;

namespace LAB3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Podawanie rozmiaru macierzy - podana wartość odpowiada zarówna za X i Y, ponieważ założyłem, że tworzę narzędzie do mnożenia macierzy kwadratowych
            Console.WriteLine("Podaj rozmiar macierzy (macierz kwadratowa): ");
            int matrixSize = int.Parse(Console.ReadLine());

    //        Console.WriteLine("Podaj ilość wątków jak ma zostać wykorzystana: ");
    //       int numberOfThreads = int.Parse(Console.ReadLine());
            // Instancja klasy MatrixMultiplier
            MatrixMultiplier matrixMultiplier = new MatrixMultiplier(matrixSize);

            // Inicjalizacja stoperów
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            Stopwatch stopwatch3 = new Stopwatch();
            Stopwatch stopwatch4 = new Stopwatch();


            // Mnożenie macierzy po kolei
            //            stopwatch.Start();
            //            matrixMultiplier.MultiplySequential();
            //            stopwatch.Stop();
            //            Console.WriteLine($"Sequential multiplication took: {stopwatch.ElapsedMilliseconds} ms");
            // matrixMultiplier.DisplayMatrices();

            // Równoległe mnożenie macierzy z wykorzystaniem X wątków
            //            stopwatch2.Start();
            //            matrixMultiplier.MultiplyParallel(numberOfThreads);
            //            stopwatch2.Stop();
            //            Console.WriteLine($"Parallel multiplication with {numberOfThreads} threads took: {stopwatch2.ElapsedMilliseconds} ms");
            // matrixMultiplier.DisplayMatrices();

            // Inicjalizacja zmiennych do przechowania czasu wykonania
            TimeSpan ts = TimeSpan.Zero;
            TimeSpan ts3 = TimeSpan.Zero;
            TimeSpan ts4 = TimeSpan.Zero;
            
            // Tablica do uruchomienia obliczeń z różnymi ilościami wątków
            int[] threadCounts = { 1, 2, 4, 8 };

            // Tworzenie pierwszego wierza tabelki w konsoli
            Console.WriteLine("+--------------+---------------+-----------------+---------------------+");
            Console.WriteLine("| Ilość wątków |     Thread    |     Parallel    |     Sekwencyjnie    |");
            Console.WriteLine("+--------------+---------------+-----------------+---------------------+");

            // Pętla dla różnych ilości wątków
            for (int j = 0; j < 4; j++)
            {
                ts = TimeSpan.Zero;
                ts3 = TimeSpan.Zero;
                ts4 = TimeSpan.Zero;

                for (int i = 0; i < 10; i++)
                {
                    if (i == 0)
                    {
                        stopwatch3.Start();
                    }
                    else
                    {
                        stopwatch3.Restart();
                    }
                    matrixMultiplier.MultiplyParallel(threadCounts[j]); // Z użyciem klasy Thread
                    stopwatch3.Stop();
                    ts3 += stopwatch3.Elapsed;
                }
                for (int i = 0; i < 10; i++)
                {
                    if (i == 0)
                    {
                        stopwatch4.Start();
                    }
                    else
                    {
                        stopwatch4.Restart();
                    }
                    matrixMultiplier.MultiplyParallel2(threadCounts[j]); // Z użyciem bilbioteki Parallel
                    stopwatch4.Stop();
                    ts4 += stopwatch4.Elapsed;
                }
                ts3 = ts3 / 10;
                ts4 = ts4 / 10;
                if (j == 0)
                {
                    stopwatch.Start();
                    matrixMultiplier.MultiplySequential(); // Sekwencyjnie
                    stopwatch.Stop();
                    ts = stopwatch.Elapsed;
                    // Dla pierwszego przejścia macierze są mnożone również sekwencyjnie, po czym wynik zostaje wyświetlony w porównaniu
                    Console.WriteLine($"| {threadCounts[j], -12} |     {ts3.Milliseconds}ms     |      {ts4.Milliseconds}ms      |        {ts.Milliseconds}ms        |");
                }
                else
                {
                    // Dla reszty przejść macierze liczą się tylko za pomocą Thread i Parallel, a sekwencyjnie jest wypełniane "--" co ma oznaczać brak wyniku
                    Console.WriteLine($"| {threadCounts[j], -12} |     {ts3.Milliseconds}ms     |      {ts4.Milliseconds}ms      |         --        |");
                }
            }

 //           Console.WriteLine($"Uśrednione wyniki mnożenia równoległego macierzy w 10 próbach, zwróciło nam wyniki: ");
 //           Console.WriteLine($"     - Z użyciem klasy Thread otrzymaliśmy: {ts3.Milliseconds} ms");
  //          Console.WriteLine($"     - Z użyciem biblioteki Parallel otrzymaliśmy: {ts4.Milliseconds} ms");

        }
    }
}
