using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareGame
{
    internal class GameEngine
    {
        private bool _isStartGAme;
        private static GameEngine _gameEngine;
        private Scene _scene;
        private ScreenRender _screenRender;
        private GameSettings _gameSettings;
        readonly public Random _random;

        private GameEngine()
        {

        }
        private GameEngine(GameSettings gameSettings)
        {
            _isStartGAme = true;
            _scene = Scene.GetScene(gameSettings);
            _screenRender = new ScreenRender(gameSettings);
            _gameSettings = gameSettings;
            _random = new Random();
        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (_gameEngine == null)
            {

                _gameEngine = new GameEngine(gameSettings);

            }
            return _gameEngine;
        }

        public void Run()
        {
            _screenRender.Render(_scene);
            AddFirstInformation();
            Console.ReadLine();

            for (int i = 0; i < _gameSettings.QuantityRaund; i++)
            {
                _screenRender.Render(_scene);
                FirstPlayerTurn();
                _screenRender.Render(_scene);
                SecondPlayerTurn();
                Console.ReadLine();
            }

        }
        public void AddFirstInformation()
        {
            Console.SetCursorPosition(_gameSettings.infoMsgX, _gameSettings.infoMsgY);
            Console.WriteLine(_gameSettings.helloMsg);
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("PlayerOne");
            Console.SetCursorPosition(10, 17);
            Console.WriteLine("PlayerTwo");
        }

        public bool IsAddSquare(int[] diceRoll, int[] coordinateInput, char[,] areaGame)
        {
            int rows = areaGame.GetUpperBound(0) + 1;    // rows
            int columns = areaGame.Length / rows;        // columns
            int sizeX = diceRoll[0];
            int sizeY = diceRoll[1];
            int pointX = coordinateInput[0];
            int pointY = coordinateInput[1];

            if (pointX + sizeX > columns)
            {
                return false;
            }
            if (pointY + sizeY > rows)
            {
                return false;
            }
            int checkEmty = 0;
            for (int i = pointY; i < sizeY + pointY; i++)
            {
                for (int j = pointX; j < sizeX + pointX; j++)
                {
                    if (areaGame[i, j] == ' ')
                    {
                        checkEmty++;
                    }
                }
            }
            if (checkEmty != (sizeX * sizeY))
            {
                return false;
            }
            return true;
        }

        public void ViewResult(char[,] areaGame)
        {

            int resultFirsPlayer = 0;
            int resultSecondPlayer = 0;
            int rows = areaGame.GetUpperBound(0) + 1;    // количество строк
            int columns = areaGame.Length / rows;        // количество столбцов

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (areaGame[i, j] == '#')
                    {
                        resultFirsPlayer++;
                    }
                    else if (areaGame[i, j] == '*')
                    {
                        resultSecondPlayer++;
                    }
                }
            }
            // name
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("PlayerOne");
            Console.SetCursorPosition(10, 17);
            Console.WriteLine("PlayerTwo");
            //result
            Console.SetCursorPosition(12, 9);
            Console.WriteLine(resultFirsPlayer);
            Console.SetCursorPosition(12, 19);
            Console.WriteLine(resultSecondPlayer);
            /*
            Console.WriteLine("Hello Player one:");
            Console.WriteLine(_gameSettings.helloMsg);
            */
        }

        public int[] CalculateDiceRoll()
        {
            return new int[] { _random.Next(1, 6), _random.Next(1, 6) };
        }

        public void OutputMsg(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
            Console.SetCursorPosition(0, 0);
        }

        public void ClearMsg()
        {
            OutputMsg(_gameSettings.clearMsg, _gameSettings.infoMsgX, _gameSettings.infoMsgY);
        }

        public int[] InputCoordinate(int x, int y)
        {
            string msg;
            int[] coordinate = new int[2];
            bool checkInput = true;
            do
            {
                checkInput = false;
                OutputMsg("Please input coordinate x ", x, y);
                Console.SetCursorPosition(30, y);
                msg = Console.ReadLine();
                OutputMsg("                            ", 30, y);

                try
                {
                    coordinate[0] = int.Parse(msg);
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(30, y);
                    OutputMsg("Invalid type             ", x, y);
                    checkInput = true;
                }

            } while (checkInput);

            do
            {
                checkInput = false;
                OutputMsg("Please input coordinate y ", x, y);
                Console.SetCursorPosition(30, y);
                msg = Console.ReadLine();
                OutputMsg("                            ", 30, y);

                try
                {
                    coordinate[1] = int.Parse(msg);
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(30, y);
                    OutputMsg("Invalid type             ", x, y);
                    checkInput = true;
                }

            } while (checkInput);

            return coordinate;
        }

        public char[,] GetAreaGame()
        {
            int startX = _gameSettings.upHorizontalBorderX;
            int startY = _gameSettings.VerticalLeftboarderY;
            int endX = _gameSettings.VerticalRightboarderX;
            int endY = _gameSettings.downHirizontalY;
            char[,] gameArea = new char[endY - startY, endX - startX];

            for (int i = startY; i < endY; i++)
            {
                for (int j = startX; j < endX; j++)
                {
                    if (_screenRender.ScreenMatrix[i, j] == '\0')

                    {
                        gameArea[i - startY, j - startX] = ' ';
                    }
                    else { gameArea[i - startY, j - startX] = _screenRender.ScreenMatrix[i, j]; }
                }
            }
            return gameArea;
        }

        public bool IsCanCreateSquaire(int[] arrayDice, char[,] areaGame)
        {
            int rows = areaGame.GetUpperBound(0) + 1;    // количество строк
            int columns = areaGame.Length / rows;        // количество столбцов
            int x = arrayDice[0];
            int y = arrayDice[1];

            for (int i = 0; i < rows - y; i++)
            {
                for (int j = 0; j < columns - x; j++)
                {
                    int checkIsEmty = 0;
                    for (int k = i; k < y; k++)
                    {
                        for (int l = 0; l < x; l++)
                        {
                            if (areaGame[k, l] == ' ' || areaGame[k, l] == '\0')
                            {
                                checkIsEmty++;
                            }
                        }
                    }
                    if (checkIsEmty == (x * y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public bool FirstPlayerTurn()
        {
            ClearMsg();
            char[,] areaGame = GetAreaGame();
            ViewResult(areaGame);
            OutputMsg(_gameSettings.moveFirstPlayer, _gameSettings.infoMsgX, _gameSettings.infoMsgY);
            Console.ReadLine();
            int[] arrayDice = CalculateDiceRoll();
            OutputMsg("Result dice roll: " + arrayDice[0] + " " + arrayDice[1] + "                             ", _gameSettings.infoMsgX, _gameSettings.infoMsgY);
            bool isCannCreate = IsCanCreateSquaire(arrayDice, areaGame);

            if (!isCannCreate)
            {
                OutputMsg("This square cannot add. Press enter to dice roll.", _gameSettings.infoMsgX + 2, _gameSettings.infoMsgY);
                arrayDice = CalculateDiceRoll();
                OutputMsg("Result dice roll: " + arrayDice[0] + " " + arrayDice[1], _gameSettings.infoMsgX + 3, _gameSettings.infoMsgY);
                isCannCreate = IsCanCreateSquaire(arrayDice, areaGame);
            }

            if (!isCannCreate)
            {
                OutputMsg("This square cannot add. Turn Next Player.", _gameSettings.infoMsgX + 4, _gameSettings.infoMsgY);
                return false;
            }


            int[] coordinateInput = InputCoordinate(_gameSettings.infoMsgX, _gameSettings.infoMsgY + 1);

            bool checkAddGameObject = IsAddSquare(arrayDice, coordinateInput, areaGame);

            if (checkAddGameObject)
            {
                char[,] figurePlayerOne = new char[arrayDice[1], arrayDice[0]];
                int rows = figurePlayerOne.GetUpperBound(0) + 1;    // количество строк
                int columns = figurePlayerOne.Length / rows;        // количество столбцов

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        figurePlayerOne[i, j] = '#';
                    }
                }
                GameObjectPlace objectPlace = new GameObjectPlace(_gameSettings.VerticalLeftboarderX + 2 + coordinateInput[0], _gameSettings.VerticalLeftboarderY + coordinateInput[1]);

                GameObject firstPlayerSquare = new PlayerOneSquare(figurePlayerOne, objectPlace, GameObjectType.PlayerOneSquare);
                _scene.SquareList.Add(firstPlayerSquare);
            }
            else
            {
                ClearMsg();
                Console.ForegroundColor = ConsoleColor.Red;
                OutputMsg("This square cannot add.Press enter to Move Next Player.", _gameSettings.infoMsgX + 4, _gameSettings.infoMsgY);
                Console.ReadLine();

                Console.ResetColor();
            }
            return false;
        }

        public bool SecondPlayerTurn()
        {
            ClearMsg();
            char[,] areaGame = GetAreaGame();
            ViewResult(areaGame);
            OutputMsg(_gameSettings.moveSecondPlayer, _gameSettings.infoMsgX, _gameSettings.infoMsgY);
            Console.ReadLine();
            int[] arrayDice = CalculateDiceRoll();
            OutputMsg("Result dice roll: " + arrayDice[0] + " " + arrayDice[1] + "                             ", _gameSettings.infoMsgX, _gameSettings.infoMsgY);
            bool isCannCreate = IsCanCreateSquaire(arrayDice, areaGame);

            if (!isCannCreate)
            {
                OutputMsg("This square cannot add. Press enter to dice roll.", _gameSettings.infoMsgX + 2, _gameSettings.infoMsgY);
                arrayDice = CalculateDiceRoll();
                OutputMsg("Result dice roll: " + arrayDice[0] + " " + arrayDice[1], _gameSettings.infoMsgX + 3, _gameSettings.infoMsgY);
                isCannCreate = IsCanCreateSquaire(arrayDice, areaGame);
            }

            if (!isCannCreate)
            {
                OutputMsg("This square cannot add. Turn Next Player.", _gameSettings.infoMsgX + 4, _gameSettings.infoMsgY);
                return false;
            }

            int[] coordinateInput = InputCoordinate(_gameSettings.infoMsgX, _gameSettings.infoMsgY + 1);

            bool checkAddGameObject = IsAddSquare(arrayDice, coordinateInput, areaGame);

            if (checkAddGameObject)
            {
                char[,] figurePlayerOne = new char[arrayDice[1], arrayDice[0]];
                int rows = figurePlayerOne.GetUpperBound(0) + 1;    // количество строк
                int columns = figurePlayerOne.Length / rows;        // количество столбцов

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        figurePlayerOne[i, j] = '*';
                    }
                }
                GameObjectPlace objectPlace = new GameObjectPlace(_gameSettings.VerticalLeftboarderX + 2 + coordinateInput[0], _gameSettings.VerticalLeftboarderY + coordinateInput[1]);

                GameObject firstPlayerSquare = new PlayerOneSquare(figurePlayerOne, objectPlace, GameObjectType.PlayerOneSquare);
                _scene.SquareList.Add(firstPlayerSquare);
            }
            else
            {
                ClearMsg();
                Console.ForegroundColor = ConsoleColor.Red;
                OutputMsg("This square cannot add.Press enter to Move Next Player.", _gameSettings.infoMsgX + 4, _gameSettings.infoMsgY);
                Console.ReadLine();

                Console.ResetColor();
            }
            return false;
        }
    }
}
