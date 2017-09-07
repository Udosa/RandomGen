using System;


namespace ConsoleApp1
{
    public class Program
    {
        private static readonly ulong m = Int64.MaxValue;
        private static readonly ulong a = 1103515245;
        private static readonly ulong b = 12345;
        private static ulong current = 2;
        
        private static double next()
        {
            return Convert.ToDouble(current = ((a * current + b) % m)) / Int64.MaxValue;
        }

        public static void Main(string[] args)
        {

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"log.txt"))

                for (int i = 0; i < 100000; i++)
            {
                string line = String.Format("{0:0.00000000000}", next());
                    //int x = int.Parse(line);
                    //x = x + x ;
                    Console.WriteLine(line);
                    file.WriteLine(line);
            
                }

            Console.ReadLine();
        }
    }
}
