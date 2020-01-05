using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumberFromUser();

            Calculator.PrintFactors(number);
            Calculator.IsPerfectNumber(number);
            Calculator.IsPrimeNumber(number);

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompt the user for an integer.  Make sure they enter a valid integer!
        /// 
        /// See the String Input lesson for TryParse() examples
        /// </summary>
        /// <returns>the user input as an integer</returns>
        static int GetNumberFromUser()
        {

            while (true)
            {
                Console.Write("What number would you like to factor? ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("That is not a valid number.");
                }
            }


        }
    }

    class Calculator
    {
        /// <summary>
        /// Given a number, print the factors per the specification
        /// </summary>
        public static void PrintFactors(int number)
        {
            int x;

            Console.Write("The factors of {0} are: ", number);
            
            for (x = 1; x <= number; x++)
            {
                if (number % x == 0)
                {
                    Console.Write("{0} ", x);
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Given a number, print if it is perfect or not
        /// </summary>
        public static void IsPerfectNumber(int number)
        {
            int x;
            int _IsPerfect = 0;

            for (x = 1; x <= number; x++)
            {
                if (number % x == 0)
                {
                    _IsPerfect += x;
                }
            }

            _IsPerfect -= number;

            if (_IsPerfect.Equals(number))
            {
                Console.WriteLine("{0} is a perfect number.", number);
            }
            else
            {
                Console.WriteLine("{0} is not a perfect number.", number);
            }
        }

        /// <summary>
        /// Given a number, print if it is prime or not
        /// </summary>
        public static void IsPrimeNumber(int number)
        {
            int x;
            int _IsPrime = 0;

            for (x = 1; x <= number; x++)
            {
                if (number % x == 0)
                {
                    _IsPrime++;
                }
            }

            if (_IsPrime == 2)
            {
                Console.WriteLine("{0} is a prime number.", number);
            }
            else
            {
                Console.WriteLine("{0} is not a prime number.", number);
            }

        }
    }
}
