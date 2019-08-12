using System;
using Factorizor.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.UI
{
    public class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to A Better, Tested, Factorizor!\n\n");
            Console.WriteLine("Press any key to begin...");
            Console.ReadKey();
        }

        public static void DisplayFactors(int number, int[] factorArr)
        {
            Console.WriteLine($"The Factors of {number} are: {string.Join(" ", factorArr)}");
        }

        public static void DisplayPerfect(int number, bool _IsPerfect)
        {
            if (!_IsPerfect)
                Console.WriteLine($"{number} is not a Perfect Number.");
            else
                Console.WriteLine($"{number} is a Perfect Number.");
        }

        public static void DisplayPrime(int number, bool _IsPrime)
        {
            if (!_IsPrime)
                Console.WriteLine($"{number} is not a Prime Number.");
            else
                Console.WriteLine($"{number} is a Prime Number.");
        }
    }
}
