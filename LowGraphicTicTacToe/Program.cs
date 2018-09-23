using LowGraphicTicTacToe.Scenes;
using System;

namespace LowGraphicTicTacToe
{
    /// <summary>
    /// Class for starting the consoleapp
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method starts the application
        /// and defines the Settings for the Consolewindow
        /// </summary>
        static void Main()
        {
            try
            {
                StartScene.StartGame();
            }
            catch (Exception)
            {
                GameRule.ChangeConsoleColor(ConsoleColor.Red);
                Console.WriteLine("Fatal Error\n I'm sorry for the Inconveniences\nPress any Key to go back to the Mainmenu");
                if (Console.ReadKey(true).Key != ConsoleKey.Escape)
                    StartScene.StartGame();
            }
        }
    }
}
