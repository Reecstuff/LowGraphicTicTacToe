using System;

namespace LowGraphicTicTacToe
{
    class SaveGame
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public ConsoleColor FieldColor { get; private set; }

        public SaveGame(Player player)
        {
            PosX = player.PosX;
            PosY = player.PosY;
            FieldColor = player.PlayerColor;
        }
    }
}
