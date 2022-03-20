 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareGame
{
    abstract class GameObject
    {
        public GameObjectPlace GameObjectPlace { get; set; }
        public char[,] Figure { get; set; }
        public int WeightObject { get; set; }
        public int HieghtObject { get; set; }
        public GameObjectType GameObjectType { get; set; }


        public GameObject(char[,] figure, GameObjectPlace gameObjectPlace, GameObjectType gameObjectType)
        {
            GameObjectPlace = gameObjectPlace;
            Figure = figure;
            GameObjectType = gameObjectType;
        }
        public abstract char[,] ObjectToCharArray();
        


    }
}
