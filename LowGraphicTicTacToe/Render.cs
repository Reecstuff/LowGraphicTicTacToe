using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LowGraphicTicTacToe.Scenes
{
    /// <summary>
    /// Renders the Gameboard
    /// </summary>
    class Render
    {

        /// <summary>
        /// Draw squares to draw the Board
        /// </summary>
        /// <remarks>
        /// Draw playerposition and saved player selection
        /// </remarks>
        /// <param name="player">Current Player</param>
        public static void ConsoleDraw(Player player)
        {
            if (GameRule.repeat > 21)
            {
                return;
            }

            int cursorX = 0;
            int cursorY = 0;

            ConsoleColor pencilcolour = ConsoleColor.Red;

            Console.Clear();
            for (int l = 0; l < GameRule.repeat; l++)
            {
                cursorX = 0;
                cursorY = l * GameRule.sizeY;
                for (int r = 0; r < GameRule.repeat; r++)
                {
                    cursorX = r * GameRule.sizeX;

                    if (pencilcolour == ConsoleColor.Red)
                    {
                        pencilcolour += 2;

                    }
                    else
                    {
                        pencilcolour = ConsoleColor.Red;
                    }

                    GameRule.ChangeConsoleColor(pencilcolour);

                    for (int y = cursorY; y < GameRule.sizeY + cursorY; y++)
                    {
                        for (int x = cursorX; x < GameRule.sizeX + cursorX; x++)
                        {
                            if (y == cursorY || y == GameRule.sizeY - 1 + cursorY || x <= cursorX + 1 || x >= GameRule.sizeX - 2 + cursorX)
                            {
                                DrawAt(GameRule.symbol, x, y);
                            }
                            else
                            {
                                SaveGame sg = GameRule.currentPlayer.PlayerSave.Concat(GameRule.nextPlayer.PlayerSave).ToList().Find(s => s.PosX == r && s.PosY == l);
                                if (r == player.PosX && l == player.PosY)
                                {
                                    if (sg != null)
                                    {
                                        GameRule.ChangeConsoleColor(pencilcolour);
                                    }
                                    else
                                    {
                                        GameRule.ChangeConsoleColor(player.PlayerColor);
                                    }
                                    DrawAt(GameRule.symbol, x, y);
                                }
                                else if (sg != null)
                                {
                                    GameRule.ChangeConsoleColor(sg.FieldColor);
                                    DrawAt(GameRule.symbol, x, y);
                                }
                                GameRule.ChangeConsoleColor(pencilcolour);
                            }
                        }
                    }
                }
            }
            GameRule.ChangeConsoleColor(GameRule.currentPlayer.PlayerColor);
            StartScene.FreeLines(2);
            Console.WriteLine(string.Concat("It is ", GameRule.currentPlayer.PlayerName, "'s turn"));
        }

        /// <summary>
        /// Draw a character at a specific position
        /// </summary>
        /// <param name="c">Character</param>
        /// <param name="x">X Postion</param>
        /// <param name="y">Y Postion</param>
        public static void DrawAt(char c, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

    }
}
