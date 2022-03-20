using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareGame
{
    internal class PlayerTwoSquare : GameObject
    {
        public PlayerTwoSquare(char[,] figure, GameObjectPlace gameObjectPlace, GameObjectType gameObjectType) : base(figure, gameObjectPlace, gameObjectType)
        {
        }

        public override char[,] ObjectToCharArray()
        {
            return Figure;
        }
    }
}
