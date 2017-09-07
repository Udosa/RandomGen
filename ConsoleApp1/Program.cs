using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleApp1
{
    public class Program
    {
        private static readonly int count = 100_000;
        private static readonly ulong m = Int64.MaxValue;
        private static readonly ulong a = 1103515245;
        private static readonly ulong b = 12345;
        private static ulong current = ((ulong) DateTime.Now.Ticks) % m;

        private static double Next()
        {
            return Convert.ToDouble(current = ((a * current + b) % m)) / Int64.MaxValue;
        }

        public static void Main(string[] args)
        {
            double[] numbers = Enumerable.Range(0, count).Select(x => Next()).ToArray();
            double average = numbers.Average();
            double dispersion = numbers.Select(number => (number - average) * (number - average)).Sum() / count;
            double squareRootOfDispersion = Math.Sqrt(dispersion);
            using (StreamWriter file = new StreamWriter(@"numbers.txt"))
            {
                numbers.Select(number => String.Format("{0:0.00000000000}", number)).ToList().ForEach(file.WriteLine);
            }
            List<string> log = new List<string>
            {
                String.Format("Numbers ({0}) are in file numbers.txt", count),
                String.Format("Average: {0}", average),
                String.Format("Dispersion: {0}", dispersion),
                String.Format("Square root of dispersion: {0}", squareRootOfDispersion)
            };
            log.ForEach(Console.WriteLine);
            using (StreamWriter file = new StreamWriter(@"log.txt"))
            {
                log.ForEach(file.WriteLine);
            }
            Console.ReadLine();
        }
    }
}
