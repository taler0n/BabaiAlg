using CryptoAlg;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabaiAlg
{
    public class Babai
    {
        public static Vector FindClosest(Matrix basis, Vector x)
        {
            var reducedBasis = LLL.LLLreduction(basis);
            Console.WriteLine("LLL-редуцированный базис:");
            reducedBasis.ConsolePrint();
            Console.WriteLine();

            Matrix gramVectors;
            Matrix gramCoef;
            LLL.GramSchmidt(basis, out gramVectors, out gramCoef);
            Console.WriteLine("Ортогонализированные векторы:");
            gramVectors.ConsolePrint();
            Console.WriteLine();
            Console.WriteLine();

            var xi = new Vector(x);
            var closest = new Vector(x.Length);
            for (int i = x.Length - 1; i >= 0; i--)
            {
                Console.WriteLine("Шаг {0}", x.Length - i);
                Console.WriteLine("Вектор x{0}:", i + 1);
                xi.ConsolePrint();
                Console.WriteLine();

                double r = xi.DotProduct(gramVectors[i]) / gramVectors[i].DotProduct(gramVectors[i]);
                int m = Convert.ToInt32(Math.Floor(r + 0.5));
                Console.WriteLine("r = {0}; m = {1}", r, m);
                Console.WriteLine();

                var y = m * reducedBasis[i];
                Console.WriteLine("Вектор y:");
                y.ConsolePrint();
                Console.WriteLine();
                Console.WriteLine();

                closest = closest + y;
                xi = xi + ((m - r) * gramVectors[i]) - y;
            }
            return closest;
        }
    }
}
