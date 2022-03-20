using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareGame
{
    internal class HorizontalBordder : GameObject
    {
        public HorizontalBordder(char[,] figure, GameObjectPlace gameObjectPlace, GameObjectType gameObjectType) : base(figure,gameObjectPlace, gameObjectType)
        {
        }

        public override char[,] ObjectToCharArray()
        {
            int rows = Figure.GetUpperBound(0) + 1;    // количество строк
            int columns = Figure.Length / rows;        // количество столбцов
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++) 
                {
                    if (i == 0)
                    {
                        Figure[i, j] = '=';
                    }
                    else if (i == 1)
                    {
                        string msg = (j / 10).ToString();
                        Figure[i, j] = msg[0];
                    }
                    else if (i == 2)
                    {
                        string msg = (j % 10).ToString();
                        Figure[i, j] = msg[0];
                    }
                    else if (i == 3) 
                    {
                        Figure[i, j] = '=';
                    }

                }
            }

            return Figure;
        }
    }
}
