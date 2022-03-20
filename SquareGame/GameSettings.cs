using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareGame
{
    internal class GameSettings
    {
        //Size display area:
        public int ConsoleWeight { get; set; } = 100;
        public int ConsoleHeight { get; set; } = 30;

        //------------------------------------------
        //Size game area:
        public static int AreaLenghtX { get; set; } = 30;
        public static int AreaLenghtY { get; set; } = 20;
        public static int AreaStartCoordinateX { get; set; } = 30;
        public static int AreaStertCoordinateY { get; set; } = 4;

        //------------------------------------------
        // Vertical border:
        public static int weightVerticalBorder { get; set; } = 2;
        public static int lenghtVerticalBorder { get; set; } = AreaLenghtY;
        public char[,] verticalBorder { get; set; } = new char[lenghtVerticalBorder, weightVerticalBorder];
        public int VerticalLeftboarderX { get; set; } = AreaStartCoordinateX;
        public int VerticalLeftboarderY { get; set; } = AreaStertCoordinateY;
        public int VerticalRightboarderX { get; set; } = AreaStartCoordinateX + weightVerticalBorder + AreaLenghtX;

        //------------------------------------------
        // Horizontal border:
        public static int weightHorizontalBorder { get; set; } = 4;
        public char[,] horizontalBorder { get; set; } = new char[weightHorizontalBorder, AreaLenghtX];
        public int upHorizontalBorderX { get; set; } = AreaStartCoordinateX + weightVerticalBorder;
        public int upHorizontalBorderY { get; set; } = AreaStertCoordinateY- weightHorizontalBorder;
        public int downHirizontalX { get; set; } = AreaStartCoordinateX + weightVerticalBorder;
        public int downHirizontalY { get; set; } = AreaStertCoordinateY + lenghtVerticalBorder;


        //------------------------------------------
        //Player one info:
        public int PlayerOneInformationX { get; set; } = 3;
        public int PlayerOneInformationY { get; set; } = 5;
        public char PlayerOneCharacter { get; set; } = '*';
        public string PlayerOneName { get; set; } = "Player One";
        //------------------------------------------
        //Player two  info:
        public int PlayerTwoInformationX { get; set; } = 3;
        public int PlayerTwoInformationY { get; set; } = 16;
        public char PlayerTwoCharacter { get; set; } = '#';
        public string PlayerTwoName { get; set; } = "PlayerTwo";
        //------------------------------------------
        // Player info:
        public char[,] InfoAboutPlayerChar { get; set; } = { { ' ','P','l','a','y','e','r',' ',' ',' ',' ',' ',},
                                                              { 'N','a','m','e',':',' ',' ',' ',' ',' ',' ',' '},
                                                              { 'A','t','t','e','m','p','t','s',':',' ',' ',' '},
                                                              { 'F','i','g','u','r','e',':',' ',' ',' ',' ',' '},
                                                              { 'R','e','s','u','l','t',':',' ',' ',' ',' ',' '}
                                                           };

        public int PlayerQuantityOfMove { get; set; } = 20;
        public int PlayerQuantityOfAttempts { get; set; } = 2;




        // Game Info: 
        public int QuantityRaund { get; set; } = 20;
        public string helloMsg = "Hello!!! This game is SquareGames. Each of You have 20 attempts.";
        
        public int infoMsgX = 5;
        public int infoMsgY = 32;

        public string clearMsg = "                                                                      " +
            "                                                                      " +
            "                                                                      " +
            "                                                                      " +
            "                                                                      ";

        
        //------------------------------------------
        //Move player:
        public string moveFirstPlayer = "First player press \"Enter\" to roll the dice.                    ";
        public string moveSecondPlayer = "Second player press \"Enter\" to roll the dice.                   ";
        //public string moveLastPlayer =

        //------------------------------------------




        /*             1         2         3         4         5         6         7         8         9        10
         *   0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789 =ConsoleWeight = 100
         *   1
         *   2                             0         1         2         3
         *   3    PlayerOne                0123456789012345678901234567890  =30               Message:
         *   4    Name:  PlayerOne        0                               0
         *   5    Number of attempts      1                               1
         *   6          20                2                               2
         *   7    Figure : *              3                               3
         *   8                            4                               4
         *   9    RESULT:                 5                               5
         *  11                            6                               6
         *  12    #1: 5                   7                               7
         *  13    #2: 6                   8                               8
         *  14                            9                               9
         *  15                           10                               10
         *  16    PlayerTWo              11                               11
         *  17    Name:  PlayerTwo       12                               12
         *  18    Number of attempts     13                               13
         *  19           20              14                               14
         *  20    Figure : #             15                               15
         *  21                           16                               16
         *  22    RESULT:                17                               17
         *  23                           18                               18
         *  24    #1: 3                  19                               19
         *  25    #2: 4                  20                               20
         *  26                             0123456789012345678901234567890
         *  27                             0         1         2         3
         *  28
         *  29
         *  30
         *  ||
         *  ConsoleHeight=30
         *  
         *  
         */
    }
}
