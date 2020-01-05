using System;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI;

namespace BattleShip.UI
{
    public class Gameflow
    {
        public void PlayBattleship()
        {
            while (true)
            {
                ConsoleOutput.DisplayTitle();

                Player p1 = new Player();
                Player p2 = new Player();
                p1.Name = ConsoleInput.GetPlayerName("Enter Name Player One: ");
                p2.Name = ConsoleInput.GetPlayerName("Enter Name Player Two: ");
                Console.Clear();
                Console.WriteLine($"Your turn {p1.Name}. Please place your ships.");
                Console.ReadKey();
                p1.ShipBoard = GameSetup.SetupBoard();
                Console.Clear();
                Console.WriteLine($"Your turn {p2.Name}. Please place your ships.");
                Console.ReadKey();
                p2.ShipBoard = GameSetup.SetupBoard();
                p1.HitBoard = p2.ShipBoard;
                p2.HitBoard = p1.ShipBoard;
                p1.VisualBoard = GameSetup.CreateVisualBoard();
                p2.VisualBoard = GameSetup.CreateVisualBoard();

                Console.Clear();
                Random rnd = new Random();
                int pTurn = rnd.Next(2);
                FireShotResponse response;
                Coordinate FiringCoordinate;

                while (true)
                    if (pTurn == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($"Your turn {p2.Name}. Press any key to continue...");
                        Console.ReadKey();
                        ConsoleOutput.DisplayBoard(p2.VisualBoard);
                        do
                        {
                            FiringCoordinate = ConsoleInput.GetShipCoordinates("Enter Firing Coordinates.");
                            response = p1.ShipBoard.FireShot(FiringCoordinate);
                            ConsoleOutput.OutputShotStatus(response);
                        } while (response.ShotStatus.Equals(ShotStatus.Duplicate));
                        int x = FiringCoordinate.XCoordinate;
                        int y = FiringCoordinate.YCoordinate;
                        if (response.ShotStatus.Equals(ShotStatus.Miss))
                            p2.VisualBoard[x, y] = 'M';
                        if ((response.ShotStatus.Equals(ShotStatus.Hit)) || (response.ShotStatus.Equals(ShotStatus.HitAndSunk)))
                            p2.VisualBoard[x, y] = 'H';
                        if (response.ShotStatus.Equals(ShotStatus.Victory))
                            break;
                        pTurn = 0;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Your turn {p1.Name}. Press any key to continue...");
                        Console.ReadKey();
                        ConsoleOutput.DisplayBoard(p1.VisualBoard);
                        do
                        {
                            FiringCoordinate = ConsoleInput.GetShipCoordinates("Enter Firing Coordinates.");
                            response = p2.ShipBoard.FireShot(FiringCoordinate);
                            ConsoleOutput.OutputShotStatus(response);
                        } while (response.ShotStatus.Equals(ShotStatus.Duplicate));
                        int x = FiringCoordinate.XCoordinate;
                        int y = FiringCoordinate.YCoordinate;
                        if (response.ShotStatus.Equals(ShotStatus.Miss))
                            p1.VisualBoard[x, y] = 'M';
                        if ((response.ShotStatus.Equals(ShotStatus.Hit)) || (response.ShotStatus.Equals(ShotStatus.HitAndSunk)))
                            p1.VisualBoard[x, y] = 'H';
                        if (response.ShotStatus.Equals(ShotStatus.Victory))
                            break;
                        pTurn = 1;
                    }
                ConsoleOutput.AskToPlayAgain("Would You Like To Play Again? Y/N: ");
            }
        }
    }
}
