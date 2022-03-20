using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareGame
{
    internal class PlayerInfo : GameObject
    {
        public string Name { get; set; }
        public int QuantityOfMove { get; set; }
        public int QuantityOfAttempts  { get; set; }   

        public PlayerInfo (char[,] figure,GameObjectPlace gameObjectPlace,GameObjectType gameObjectType,int quantityOfMove, int quantityOfAttempts,string name)
            : base(figure,gameObjectPlace, gameObjectType)
        {
            QuantityOfAttempts = quantityOfAttempts;
            QuantityOfMove = quantityOfMove;
            Name = name;
            
        }

        public override char[,] ObjectToCharArray()
        {
            

            return Figure; 
        }
    }
}
