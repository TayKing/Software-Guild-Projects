using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer;
            string playerInput;
            int numOfTries = 0;
            int maxNum = 0;
            string playerName;

            void errMessage(string value)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(value);
                Console.ResetColor();
            }

            void vicMessage(string value)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(value);
                Console.ResetColor();
            }



            while (true)
            {
                Console.Write("Please Enter Name: ");
                playerName = Console.ReadLine();

                if (!string.IsNullOrEmpty(playerName))
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write($"{playerName} pick a game mode: E-Easy N-Normal H-Hard ");
                string gameMode = Console.ReadLine();

                if (gameMode == "e" || gameMode == "E")
                {
                    maxNum = 5;
                    break;
                }
                else if (gameMode == "n" || gameMode == "N")
                {
                    maxNum = 20;
                    break;
                }
                else if (gameMode == "h" || gameMode == "H")
                {
                    maxNum = 50;
                    break;
                }
                else
                {
                    Console.WriteLine($"{playerName} that is not a valid game mode");
                }
            }

            Random r = new Random();
            theAnswer = r.Next(1, (maxNum)+ 1);

            do
            {

                // get player input
                Console.Write($"{playerName} enter your guess (1-{maxNum}): ");
                playerInput = Console.ReadLine();

                if (playerInput == "q" || playerInput == "Q")
                {
                    break;
                }

                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out int playerGuess) && playerGuess <= maxNum)
                {
                    numOfTries++;
                    if (playerGuess == theAnswer)
                    {
                        if (numOfTries == 1)
                        {
                            vicMessage($"{playerName} GOT IT ON THEIR FIRST TRY. AWESOME JOB.");
                            break;
                        }
                        else
                        {
                            vicMessage($"{theAnswer} was the number.  You Win!");
                            vicMessage($"{playerName} got it on try {numOfTries}.");
                            break;
                        }
                    }
                    else
                    {
                        if (playerGuess > theAnswer)
                        {
                            errMessage($"{playerName} Your guess was too High!");
                        }
                        else
                        {
                            errMessage($"{playerName} Your guess was too low!");
                        }
                    }
                }
                else
                {
                    errMessage($"Sorry {playerName} that wasn't a valid number! Try Again!");
                }

            } while (true);
            vicMessage("GAME OVER");
            Console.ResetColor();
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
