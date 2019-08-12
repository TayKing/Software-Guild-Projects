using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
            Console.ReadLine();
        }

        static void Execute()
        {
            
            for (int i = 1; i <=100; i++)
            {
                Console.Write( "{0} ", i);
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write("FizzBizz");
                }
                else if (i % 3 == 0)
                {
                    Console.Write("Fizz");
                }
                else if (i % 5 == 0) 
                {
                    Console.Write("Bizz");
                }
                Console.WriteLine();
            }
        }
    }
}
