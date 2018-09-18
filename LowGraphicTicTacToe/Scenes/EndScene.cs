﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LowGraphicTicTacToe.Scenes
{
    /// <summary>
    /// Checking if someone has won and showing the endscreen
    /// </summary>
    static class EndScene
    {
        /// <summary>
        /// If someone has one show the endmessage
        /// </summary>
        /// <returns>If game has ended</returns>
        public static bool CheckWin()
        {
            if (CheckEnumeration())
            {
                GameEnd(String.Join(" ", GameRule.currentPlayer.PlayerName, "has won the Game!"), GameRule.currentPlayer.PlayerColor);
                return true;
            }
            else if (GameRule.turn == GameRule.repeat * GameRule.repeat)
            {
                GameEnd("DRAW!");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Show endmessage in a specific color
        /// </summary>
        /// <param name="s">Endmessage</param>
        /// <param name="c">Endcolor</param>
        private static void GameEnd(string s, ConsoleColor c = ConsoleColor.Yellow)
        {
            GameRule.ChangeConsoleColor(c);
            Console.WriteLine(s);
            GameRule.ChangeConsoleColor(ConsoleColor.Red);
            Console.WriteLine("Press any key to get back to the menu");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Check if current player has finished the game
        /// </summary>
        /// <returns>If current player finished the game</returns>
        private static bool CheckEnumeration()
        {
            int checksum = Convert.ToInt32(Math.Ceiling((decimal)GameRule.repeat / 2)) * 2;
            int winEqual = 0;
            int winCheck = 0;
            List<SaveGame> sGList = GameRule.currentPlayer.PlayerSave.OrderBy(s => s.PosX).ThenBy(s => s.PosY).ToList();

            for (int i = 0; i < sGList.Count; i++)
            {
                if (sGList.Count(x => x.PosX == i) == GameRule.repeat || sGList.Count(y => y.PosY == i) == GameRule.repeat)
                {
                    return true;
                }
                else if (sGList[i].PosX == sGList[i].PosY)
                {
                    winEqual++;

                    if (winEqual == GameRule.repeat)
                    {
                        return true;
                    }
                }
                else if ((sGList[i].PosX + sGList[i].PosY) == checksum)
                {
                    winCheck++;

                    if (winCheck == GameRule.repeat)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
