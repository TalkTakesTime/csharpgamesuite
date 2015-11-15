using System;
using System.Collections.Generic;
using System.Text;

namespace GameSuite.Games.ConnectFour
{
    public class Game : IGame<Game, Move>
    {
        public uint Height { get; }
        public uint Width { get; }
        private byte[,] Grid;
        private Stack<Move> History;
        private byte CurrPlayer; // should this be private or public?

        /// <summary>
        /// Creates a default empty 6x7 board.
        /// </summary>
        public Game() : this(6, 7) { }

        /// <summary>
        /// Creates a board with the given dimensions.
        /// </summary>
        /// <param name="height">The height of the board</param>
        /// <param name="width">The width of the board</param>
        public Game(uint height, uint width)
        {
            Height = height;
            Width = width;
            CurrPlayer = 1;
            Grid = new byte[Height, Width];
            History = new Stack<Move>();
        }

        /// <summary>
        /// Creates a game using a pre-existing history, giving a game with
        /// some moves already played.
        /// </summary>
        /// <param name="height">The height of the board</param>
        /// <param name="width">The width of the board</param>
        /// <param name="history">The history of moves to use</param>
        public Game(uint height, uint width, Stack<Move> history) :
            this(height, width)
        {
            // iterating through a stack occurs in LIFO order so we have to
            // copy it into a List and reverse it before we can add the moves
            // in the right order
            // TODO: fix this? improve efficiency at least
            var moves = new List<Move>(history);
            moves.Reverse();

            foreach (Move m in moves)
            {
                if (!Play(m))
                {
                    throw new ArgumentException(
                        "history contains an invalid move");
                }
                History.Push(m);
            }
        }


        /// <summary>
        /// Places the given move on the board, returning true if the move is
        /// valid or false if: it is in a full column; it is in a non-existent
        /// column; or if it is by an invalid player. A valid move will be
        /// stored in the history.
        /// </summary>
        /// <param name="move">The move to play</param>
        /// <returns>
        /// true if the move is valid and played, otherwise false.
        /// </returns>
        public bool Play(Move move)
        {
            // ensure column and player are valid
            if (move.Col >= Width || move.Player < 1 ||
                move.Player > 2 || move.Player != CurrPlayer)
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
            // store the move in history and adjust the current player
            History.Push(move);
            CurrPlayer = (byte) (CurrPlayer == 1 ? 2 : 1);

            return true;
        }


        /// <summary>
        /// Checks if the given move is valid and can be played.
        /// </summary>
        /// <param name="move">The move to test</param>
        /// <returns>true if the move can be played, otherwise false</returns>
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
            var dict = new Dictionary<byte, string> {
                { 0, "_" },
                { 1, "o" },
                { 2, "x" }
            };
            var border = "+" + new string('-', (int) Width * 2 + 1) + "+";

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


        /// <summary>
        /// Generates a list of all the moves which are valid to play
        /// immediately for this game.
        /// </summary>
        /// <returns>A list of valid moves</returns>
        public List<Move> GenerateMoves()
        {
            var validMoves = new List<Move>();
            Move m;

            for (uint col = 0; col < Width; col++)
            {
                m = new Move(CurrPlayer, col);
                if (CanPlay(m))
                    validMoves.Add(m);
            }

            return validMoves;
        }


        /// <summary>
        /// Creates a game which is the child of this one, i.e, it is the same
        /// with the addition of the specified move.
        /// </summary>
        /// <param name="move">The move to play in the child game</param>
        /// <returns>
        /// A Game with the same moves played, plus the additional given move.
        /// </returns>
        public Game GenerateChild(Move move)
        {
            var child = new Game(Height, Width, History);

            if (!child.Play(move))
                throw new ArgumentException(
                    "the given move is not a valid move for this game");

            return child;
        }


        /// <summary>
        /// Evaluates the state of the game returning a number which indicates
        /// the player who has an advantage.
        ///
        /// TODO: determine how to evaluate the board.
        /// </summary>
        /// <returns>
        /// A number indicating the player with an advantage:
        ///   - &gt;0 if player 1 has an advantage
        ///   - 0 if neither player has an advantage
        ///   - &lt;0 if player 2 has an advantage
        /// </returns>
        public int Evaluate()
        {
            // TODO: work out how to evaluate the board
            // for now, returning 0 will cause minimax to choose randomly (ish)
            return 0;
        }


        /// <summary>
        /// Undoes the most recent move. Does nothing if no moves have been
        /// played.
        /// </summary>
        public void Undo()
        {
            if (History.Count == 0)
                return;

            var move = History.Pop();

            var row = 0;
            // find the first filled cell
            while (row < Height && Grid[row, move.Col] == 0)
                row++;

            Grid[row, move.Col] = 0;
        }
    }
}
