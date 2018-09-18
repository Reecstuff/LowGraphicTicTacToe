using System;
using System.Collections.Generic;

namespace LowGraphicTicTacToe
{
    class Player
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public List<SaveGame> PlayerSave { get; set; }

        public string PlayerName { get; private set; }
        public ConsoleColor PlayerColor { get; private set; }

        public Player(string playerName, ConsoleColor playerColor)
        {
            PosX = 0;
            PosY = 0;
            PlayerName = playerName;
            PlayerColor = playerColor;
            PlayerSave = new List<SaveGame>();
        }
    }
}
