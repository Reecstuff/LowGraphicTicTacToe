using System;

namespace LowGraphicTicTacToe
{
    /// <summary>
    /// Global values and methods
    /// </summary>
    static class GameRule
    {
        /// <param name="symbol">Special Unicode Symbol</param>
        /// <example>\u2588 = █</example>
        public const char symbol = '\u2588';

        /// <param name="sizeX">Defined x size to make a square</param>
        public const int sizeX = 8;

        /// <param name="sizeY">Defined y size to make a square</param>
        public const int sizeY = 4;

        /// <param name="repeat">Defines the size of the board</param>
        public static int repeat = 3;

        /// <param name="turn">How many gamemoves were made</param>
        public static int turn;

        /// <param name="currentPlayer">The current Player</param>
        public static Player currentPlayer;

        /// <param name="nextPlayer">The next Player</param>
        public static Player nextPlayer;

        /// <summary>
        /// Changes the consolecolors
        /// </summary>
        /// <param name="color">Color to put</param>
        /// <param name="isBackgroundColor">If you want to change the Background</param>
        public static void ChangeConsoleColor(ConsoleColor color, bool isBackgroundColor = false)
        {
            if (!isBackgroundColor)
            {
                if (color == Console.BackgroundColor)
                {
                    color += 3;
                }

                Console.ForegroundColor = color;
                return;
            }
            Console.BackgroundColor = color;
        }

    }
}
