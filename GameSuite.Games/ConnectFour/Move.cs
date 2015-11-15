namespace GameSuite.Games.ConnectFour
{
    public class Move : IMove<Game>
    {
        public byte Player { get; }
        public uint Col { get; }

        public Move(byte player, uint col)
        {
            Player = player;
            Col = col;
        }
    }
}
