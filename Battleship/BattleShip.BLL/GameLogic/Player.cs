using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.GameLogic
{
    public class Player
    {
        public string Name { get; set; }
        public Board ShipBoard { get; set; }
        public Board HitBoard { get; set; }
        public char[,] VisualBoard { get; set; }
    }
}
