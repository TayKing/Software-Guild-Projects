using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.UI
{
    class ConsoleInput
    {
        public static int GetFactorFromUser()
        {
            Console.Clear();

            while(true)
            {
                Console.Write("What is the number you would like to factor? ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("That was not a valid number. Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
