using BattleShip.BLL.GameLogic;
using System;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("BATTLESHIP : Naval Warfare");
            Console.WriteLine("Press any button to begin...");
            Console.ReadKey();
        }

        public static void DisplayBoard(char[,] visualboard)
        {
            Console.Write("   1 2 3 4 5 6 7 8 9 10");
            for(int i = 0; i <= 10; i++)
            {
                for(int j = 0; j <= 10; j++)
                {
                    if(visualboard[i,j].Equals('M'))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (visualboard[i, j].Equals('H') && j > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(string.Format(" {0}", visualboard[i, j]));

                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public static void OutputShotStatus(FireShotResponse response)
        {
            if (response.ShotStatus.Equals(ShotStatus.Duplicate))
            {
                Console.WriteLine("That is a duplicate coordinate. Please try again.");
                Console.ReadKey();
            }

            if (response.ShotStatus.Equals(ShotStatus.HitAndSunk))
            {
                Console.WriteLine("You Sunk a {0}.", response.ShipImpacted);
                Console.ReadKey();
            }

            if (response.ShotStatus.Equals(ShotStatus.Hit))
            {
                Console.WriteLine("You Got a Hit!");
                Console.ReadKey();

            }

            if (response.ShotStatus.Equals(ShotStatus.Miss))
            {
                Console.WriteLine("You missed.");
                Console.ReadKey();

            }

            if (response.ShotStatus.Equals(ShotStatus.Victory))
            {
                Console.WriteLine("You Have Sunken All Ships!");
                Console.WriteLine("YOU WIN");
                Console.ReadKey();
            }
        }

        public static bool AskToPlayAgain(string prompt)
        {
            Console.Write(prompt);
            string playagain = Console.ReadLine();

            switch(playagain)
            {
                case "y":
                case "Y":
                case "yes":
                case "Yes":
                case "YES":
                    return true;
                case "n":
                case "N":
                case "no":
                case "No":
                case "NO":
                default:
                    return false;
            }
        }
    }
}
