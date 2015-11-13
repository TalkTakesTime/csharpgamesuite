namespace GameSuite.Games.ConnectFour
{
    public class Move : IMove<Game>
    {
        public sbyte Player { get; }
        public uint Col { get; }

        public Move(sbyte player, uint col)
        {
            Player = player;
            Col = col;
        }
    }
}
