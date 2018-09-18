using System;

namespace LowGraphicTicTacToe.Scenes
{
    /// <summary>
    /// Class for initiating the game
    /// </summary>
    static class StartScene
    {
        /// <summary>
        /// Showing the Mainmenu
        /// </summary>
        public static void StartGame()
        {

            Console.ResetColor();
            Console.Clear();
            FreeLines(1);
            WriteCenter("LOW GRAPHIC TIC TAC TOE");
            FreeLines(3);
            WriteCenter("ENTER to start");
            WriteCenter("ESC to close");

            MenuSelect();
        }

        /// <summary>
        /// Waiting for the User to press ENTER or ESC
        /// </summary>
        private static void MenuSelect()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter:
                    //Choosing playernames
                    CustomizeGame();

                    //Gamestart
                    GameRule.turn = 1;
                    GameScene.ConsoleDraw(GameRule.currentPlayer);
                    Console.WriteLine(String.Concat("\n", GameRule.currentPlayer.PlayerName, " is beginning"));
                    while (GameScene.GameRun()) { }

                    //Going back to mainmenu
                    StartGame();
                    break;
                case ConsoleKey.Escape:
                    //Exit application
                    break;
                default:
                    //Recursive method call
                    MenuSelect();
                    break;
            }
        }

        /// <summary>
        /// Customize gamevalues
        /// </summary>
        private static void CustomizeGame()
        {
            String checkString;
            Console.Clear();
            Console.WriteLine("Please enter the Name of the first Player and confirm with ENTER");
            GameRule.ChangeConsoleColor(ConsoleColor.Yellow);
            checkString = Console.ReadLine().Trim();
            GameRule.currentPlayer = new Player(checkString == String.Empty ? "Player1" : checkString, ConsoleColor.Blue);
            Console.ResetColor();
            Console.WriteLine("Please enter the Name of the second Player and confirm with ENTER");
            GameRule.ChangeConsoleColor(ConsoleColor.Yellow);
            checkString = Console.ReadLine().Trim();
            GameRule.nextPlayer = new Player(checkString == String.Empty ? "Player2" : checkString, ConsoleColor.Green);
            Console.ResetColor();
        }

        /// <summary>
        /// Writing text in the center of the console
        /// </summary>
        /// <param name="s">String to write into the Console</param>
        private static void WriteCenter(string s)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
        }

        /// <summary>
        /// Write blank lines into the console
        /// </summary>
        /// <param name="count">Amount of blank lines</param>
        public static void FreeLines(int count)
        {
            while (count > 0)
            {
                Console.WriteLine();
                count--;
            }
        }
    }
}
