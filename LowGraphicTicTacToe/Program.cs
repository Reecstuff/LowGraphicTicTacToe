using LowGraphicTicTacToe.Scenes;
using System;
using System.Text;

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
            Console.OutputEncoding = Encoding.Unicode;
            Console.WindowHeight = Console.LargestWindowHeight / 2;
            Console.WindowWidth = Console.LargestWindowWidth / 2;

            StartScene.StartGame();

        }
    }
}
