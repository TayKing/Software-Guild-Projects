using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class ConsoleInput
    {
        public static string GetPlayerName(string prompt)
        {
            Console.Clear();

            while(true)
            {
                Console.Write(prompt);
                string name = Console.ReadLine();

                if(name != "")
                {
                    return name;
                }
            }
        }

        public static Coordinate GetShipCoordinates(string prompt)
        {
            int x = 11;
            int y = 11;
            string ycoordinate = null;

            do
            {

                Console.WriteLine(prompt);

                string coordinates = Console.ReadLine();

                

                if (coordinates != "")
                {
                    ycoordinate = coordinates.Remove(0, 1);

                    int check;
                    if (int.TryParse(ycoordinate, out check))
                    {
                        y = check;
                    }

                    switch (coordinates[0])
                    {
                        case 'a':
                        case 'A':
                            x = 1;
                            break;
                        case 'b':
                        case 'B':
                            x = 2;
                            break;
                        case 'c':
                        case 'C':
                            x = 3;
                            break;
                        case 'd':
                        case 'D':
                            x = 4;
                            break;
                        case 'e':
                        case 'E':
                            x = 5;
                            break;
                        case 'f':
                        case 'F':
                            x = 6;
                            break;
                        case 'g':
                        case 'G':
                            x = 7;
                            break;
                        case 'h':
                        case 'H':
                            x = 8;
                            break;
                        case 'i':
                        case 'I':
                            x = 9;
                            break;
                        case 'j':
                        case 'J':
                            x = 10;
                            break;
                        default:
                            y = 11;
                            break;
                    }
                }
            } while (!ValidCoordinates(x, y));

                return new Coordinate(x,y);           
        }        

        public static bool ValidCoordinates(int x, int y)
        {
            if ((x <= 10 && y <= 10) && (x + y > 0))
                return true;
            else
            {
                Console.WriteLine("Invalid Coordinates. Please try again.");
                Console.ReadKey();
                return false;
            }
        }

        public static ShipDirection GetShipDirection(string prompt)
        {
            while(true)
            {
                Console.WriteLine(prompt);
                string direction = Console.ReadLine();
                direction = direction.ToLower();

                switch (direction)
                {
                    case "right":
                        return ShipDirection.Right;
                    case "down":
                        return ShipDirection.Down;
                    case "left":
                        return ShipDirection.Left;
                    case "up":
                        return ShipDirection.Up;
                }
                
            }
        }
    }
}
