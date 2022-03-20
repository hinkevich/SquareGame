using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareGame
{
    internal class VerticalBorderObject : GameObject
    {
        public VerticalBorderObject(char[,] figure, GameObjectPlace gameObjectPlace, GameObjectType gameObjectType) : base(figure,gameObjectPlace, gameObjectType)
        {
        }

        public override char[,] ObjectToCharArray()
        {
            int rows = Figure.GetUpperBound(0) + 1;    // количество строк
            int columns = Figure.Length / rows;        // количество столбцов

            for (int i = 0; i < rows; i++)
            {
                if ( i<10 )
                {
                    Figure[i,0] = '0';
                    string msg =i.ToString();
                    Figure[i,1] = msg[0];
                }else 
                {
                    string msg = i.ToString();
                    Figure[i, 0] = msg[0];
                    Figure[i, 1] = msg[1];

                }
            }
            return Figure;
        }
    }
}
