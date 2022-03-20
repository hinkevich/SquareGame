using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareGame
{
    internal class ScreenRender
    {
        readonly int ScreenWeight;
        readonly int ScreenHeight;
        public char[,] ScreenMatrix;

        public ScreenRender(GameSettings gameSettings)
        {
            ScreenWeight = gameSettings.ConsoleWeight;
            ScreenHeight = gameSettings.ConsoleHeight;
            ScreenMatrix = new char[ScreenHeight, ScreenWeight];

            Console.WindowWidth = gameSettings.ConsoleWeight;
            Console.WindowHeight = gameSettings.ConsoleHeight+10;
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, 0);
        }

        public void Render(Scene scene)
        {
            Console.SetCursorPosition(0, 0);

            AddGameObjectRendering(scene.PlayerOneInfo);
            AddGameObjectRendering(scene.PlayerTwoInfo);
            AddGameObjectRendering(scene.VerticalBorderLeft);
            AddGameObjectRendering(scene.VerticalBorderRight);
            AddGameObjectRendering(scene.UpBorder);
            AddGameObjectRendering(scene.DownBorder);
            AddListForRendering(scene.SquareList);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < ScreenHeight; i++)
            {
                for (int j = 0; j < ScreenWeight; j++)
                {
                    if (ScreenMatrix[i, j] == '\0')
                    {
                        stringBuilder.Append(' ');
                    }
                    else
                    {
                        stringBuilder.Append(ScreenMatrix[i, j]);
                    }
                }
                stringBuilder.Append(Environment.NewLine);
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }
        public void AddGameObjectRendering(GameObject gameObject)
        {
            int startX = gameObject.GameObjectPlace.Xcoordinate;
            int startY = gameObject.GameObjectPlace.Ycoordinate;
            char[,] gameObjectChar = gameObject.ObjectToCharArray();
            int rows = gameObjectChar.GetUpperBound(0) + 1;    // количество строк
            int columns = gameObjectChar.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    ScreenMatrix[startY + i, startX + j] = gameObjectChar[i, j];
                }
            }

        }
        public void AddListForRendering(List<GameObject> list)
        {
            foreach (GameObject gameObject in list)
            {
                AddGameObjectRendering(gameObject);
            }
        }
    }
}
