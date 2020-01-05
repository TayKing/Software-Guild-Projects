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
    public class GameSetup
    {
        public static Board SetupBoard()
        {
            Console.Clear();

            Board board = new Board();

            PlaceShips(board);            

            return board;
        }

        private static void PlaceShips(Board board)
        {                        
            for(int i = 0; i < 5; i++)
            {
                var ship = Enum.GetName(typeof(ShipType), i);
                var request = new PlaceShipRequest();
                NewRequest(ship, request);
                request.ShipType = (ShipType)i;
                if (board.PlaceShip(request).Equals(ShipPlacement.Overlap))
                {
                    Console.WriteLine("Ships are overlapping. Please select different coordinate and direction.");
                    Console.ReadKey();
                    i--;
                }
            }
        }

        private static PlaceShipRequest NewRequest(string ship, PlaceShipRequest request)
        {

            request.Coordinate = ConsoleInput.GetShipCoordinates($"Please enter a coordinate for {ship}.");
            request.Direction = ConsoleInput.GetShipDirection($"Please enter a direction for {ship}.");
            return request;
        }

        public static char[,] CreateVisualBoard()
        {
            char[,] VisualBoard = new char[11, 11];
            char[] letters = Enumerable.Range('A', 'J' - 'A' + 1).Select(i => (Char)i).ToArray();
            int x = 0;

            for (int i = 1; i <= 10; i++)
            {

                for (int j = 0; j <= 10; j++)
                {
                    if (j == 0)
                    {
                        VisualBoard[i, j] = letters[x];
                        x++;
                    }
                    else
                    {
                        VisualBoard[i, j] = 'o';
                    }
                }
            }

            return VisualBoard;
        }
    }
}
