using CryptoAlg;
using System;

namespace BabaiAlg
{
    class Program
    {
        static void Main(string[] args)
        {
            var basis1 = new Matrix(new double[,] { { 1, 173, -220 }, { 0, 547, 0 }, { 0, 0, 547 } });
            var x1 = new Vector(new double[] { 33, 34, 35 });
            var basis2 = new Matrix(new double[,] { { 1, 2, 3 }, { 3, 0, -3 }, { 3, -7, 3 } });
            var x2 = new Vector(new double[] { 10, 6, 5 });

            var basis = basis2;
            var x = x2;
            Console.WriteLine("Базис решетки:");
            basis.ConsolePrint();
            Console.WriteLine();
            Console.WriteLine("Проверяемая точка:");
            x.ConsolePrint();
            Console.WriteLine();
            var closest = Babai.FindClosest(basis, x);
            Console.WriteLine("Результат алгоритма:");
            closest.ConsolePrint();
        }
    }
}
