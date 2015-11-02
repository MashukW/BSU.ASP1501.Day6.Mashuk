using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringGCD
{
    public delegate int GCDAlgorithm(int a, int b);

    public class RefactoringGCD
    {
        #region Properties to obtain of the sort algorithm (return delegate type GCDAlgorithm)
        public GCDAlgorithm Steins
        {
            get { return new GCDAlgorithm(SteinsAlgorithm); }
        }

        public GCDAlgorithm Euclidean
        {
            get { return new GCDAlgorithm(EuclideanAlgorithm); }
        }
        #endregion

        #region Public methods for the calculation of GCD
        public static int CalculateGCD(GCDAlgorithm method, int a, int b)
        {
            GCDAlgorithm algorithm = method;
            if (algorithm == null)
                throw new ArgumentNullException("Parametr 'method' is null");
            return algorithm(a, b);
        }

        public static int CalculateGCD(GCDAlgorithm method, params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentException("parametr 'numbers' is null");
            GCDAlgorithm algorithm = method;
            if (algorithm == null)
                throw new ArgumentNullException("Parametr 'method' is null");

            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
                result = algorithm(result, numbers[i]);

            return Math.Abs(result);
        }

        public static int CalculateGCDWithExecutionTime(out long executionTime, GCDAlgorithm method, int a, int b)
        {
            GCDAlgorithm algorithm = method;
            if (algorithm == null)
                throw new ArgumentNullException("Parametr 'method' is null");

            Stopwatch watch = new Stopwatch();
            watch.Start();
            int result = algorithm(a, b);
            watch.Stop();
            executionTime = watch.ElapsedTicks;
            return result;
        }

        public static int CalculateGCDWithExecutionTime(out long executionTime, GCDAlgorithm method, params int[] numbers)
        {
            GCDAlgorithm algorithm = method;
            if (algorithm == null)
                throw new ArgumentNullException("Parametr 'method' is null");

            Stopwatch timeWork = new Stopwatch();
            timeWork.Start();
            int result = CalculateGCD(method, numbers);
            timeWork.Stop();
            executionTime = timeWork.ElapsedTicks;
            return result;
        }
        #endregion

        #region Private methods algorithms for calculating GCD
        private static int EuclideanAlgorithm(int a, int b)
        {
            if (a < b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            int mod = 0;

            while (b != 0)
            {
                mod = a % b;
                a = b;
                b = mod;
            }

            return Math.Abs(a);
        }

        private static int SteinsAlgorithm(int a, int b)
        {
            if (a < 0)
                return Math.Abs(a);
            if (b < 0)
                return Math.Abs(b);
            if (a == b)
                return a;

            if (a == 0)
                return b;
            if (b == 0)
                return a;

            if (a % 2 == 0)
            {
                if (b % 2 != 0)
                    return SteinsAlgorithm(a >> 1, b);
                else
                    return SteinsAlgorithm(a >> 1, b >> 1) << 1;
            }

            if (b % 2 == 0)
                return SteinsAlgorithm(a, b >> 1);

            if (a > b)
                return SteinsAlgorithm((a - b) >> 1, b);

            return SteinsAlgorithm((b - a) >> 1, a);
        }
        #endregion
    }
}
