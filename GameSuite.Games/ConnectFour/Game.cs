using System;
using System.Collections.Generic;
using System.Text;

namespace GameSuite.Games.ConnectFour
{
    public class Game : IGame<Game, Move>
    {
        public uint Height { get; }
        public uint Width { get; }
        private sbyte[,] Grid;
        private Stack<Move> History;


        public Game() : this(6, 7) { }

        public Game(uint height, uint width)
        {
            Height = height;
            Width = width;
            Grid = new sbyte[Height, Width];
            History = new Stack<Move>();
        }


        public bool Play(Move move)
        {
            // ensure column and player are valid
            if (move.Col >= Width || move.Player < 1 || move.Player > 2)
                return false;

            var row = 0;
            // find the first filled cell
            while (row < Height && Grid[row, move.Col] == 0)
                row++;

            // if all cells in the column are filled, no move can be made
            if (row == 0)
                return false;

            // adjust to empty cell and fill it
            row -= 1;
            Grid[row, move.Col] = move.Player;
            History.Push(move);
            return true;
        }


        public bool CanPlay(Move move)
        {
            if (move.Col >= Width) return false;

            for (int row = 0; row < Height; row++)
            {
                // if any cells in the column are empty it can be played in
                if (Grid[row, move.Col] == 0)
                    return true;
            }

            return false;
        }


        public override string ToString()
        {
            var gridStr = new StringBuilder();
            var dict = new Dictionary<sbyte, string> {
                { 0, "_" },
                { 1, "o" },
                { 2, "x" }
            };
            var border = "+" + new string('-', (int)Width * 2 + 1) + "+";

            gridStr.AppendLine(border);
            for (int i = 0; i < Height; i++)
            {
                gridStr.Append("|");
                for (int j = 0; j < Width; j++)
                {
                    gridStr.Append(" " + dict[Grid[i, j]]);
                }
                gridStr.AppendLine(" |");
            }
            gridStr.Append(border);

            return gridStr.ToString();
        }

        public Game GenerateMoves()
        {
            throw new NotImplementedException();
        }

        public Game GenerateChild()
        {
            throw new NotImplementedException();
        }

        public int Evaluate()
        {
            throw new NotImplementedException();
        }

        public bool Undo()
        {
            var move = History.Pop();
            throw new NotImplementedException();
        }
    }
}
