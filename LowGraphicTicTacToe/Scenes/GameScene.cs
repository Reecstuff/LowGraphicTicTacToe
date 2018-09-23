using System;
using System.Linq;

namespace LowGraphicTicTacToe.Scenes
{
    /// <summary>
    ///Listen to userinput and Change the Game accordingly
    /// </summary>
    static class GameScene
    {
        /// <summary>
        /// Listening to userinput
        /// </summary>
        /// <returns>Game finished or canceled</returns>
        public static void GameRun()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    ChangePlayerPos(GameRule.currentPlayer.PosY - 1, key);
                    break;
                case ConsoleKey.DownArrow:
                    ChangePlayerPos(GameRule.currentPlayer.PosY + 1, key);
                    break;
                case ConsoleKey.LeftArrow:
                    ChangePlayerPos(GameRule.currentPlayer.PosX - 1, key);
                    break;
                case ConsoleKey.RightArrow:
                    ChangePlayerPos(GameRule.currentPlayer.PosX + 1, key);
                    break;
                case ConsoleKey.Enter:
                    if (!TurnEnd())
                    {
                        return;
                    }
                    break;
                case ConsoleKey.Escape:
                    return;
                default:
                    GameRun();
                    break;
            }
            GameRun();
        }

        /// <summary>
        /// Changing the Playerposition by the pressed key
        /// </summary>
        /// <param name="pos">Changed Position were the Player want to go</param>
        /// <param name="key">Pressed Key</param>
        private static void ChangePlayerPos(int pos, ConsoleKey key)
        {
            if (OutOfBoard(pos))
            {
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                        GameRule.currentPlayer.PosY = pos;
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        GameRule.currentPlayer.PosX = pos;
                        break;
                }

                Render.ConsoleDraw(GameRule.currentPlayer);
            }
        }

        /// <summary>
        /// Check if the Player wants to go out of the Board
        /// </summary>
        /// <param name="pos">The Position the Player wants to go</param>
        /// <returns>Is the Player out of the Board?</returns>
        private static bool OutOfBoard(int pos)
        {
            if (pos >= 0 && pos <= GameRule.repeat - 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// When the player ends his turn
        /// </summary>
        /// <returns>Is game over?</returns>
        private static bool TurnEnd()
        {
            if (GameRule.currentPlayer.PlayerSave.Concat(GameRule.nextPlayer.PlayerSave).ToList().Find(s => s.PosX == GameRule.currentPlayer.PosX && s.PosY == GameRule.currentPlayer.PosY) != null)
            {
                return true;
            }
            GameRule.currentPlayer.PlayerSave.Add(new SaveGame(GameRule.currentPlayer));

            //Check for wincondition
            if (EndScene.CheckWin())
            {
                return false;
            }

            GameRule.turn++;

            //Switch current player with next player
            Player bufferPlayer = GameRule.currentPlayer;
            GameRule.currentPlayer = GameRule.nextPlayer;
            GameRule.nextPlayer = bufferPlayer;

            //Set Player in the middle of the field
            GameRule.currentPlayer.PosX = GameRule.middle;
            GameRule.currentPlayer.PosY = GameRule.middle;

            //Render game
            Render.ConsoleDraw(GameRule.currentPlayer);
            return true;
        }
    }
}
