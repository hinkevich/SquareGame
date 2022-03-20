using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareGame
{
    internal class GameObjectPlace
    {
        public int Xcoordinate { get; set; }
        public int Ycoordinate { get; set; }

        public GameObjectPlace(int x, int y)
        {
            Xcoordinate = x;
            Ycoordinate = y;
        }
    }
    
}
