namespace GameSuite.Games
{
    // this may be a misuse of contravariance
    public interface IGame<T, in U>
        where T : IGame<T, U>
        where U : IMove<T>
    {
        bool CanPlay(U move);
        bool Play(U move);

        T GenerateMoves();
        T GenerateChild();

        /// <summary>
        /// Evaluates the current game state, giving a positive score if the
        /// state is better for player 1, and a negative score if the state
        /// is better for player 2.
        /// </summary>
        /// <returns>
        /// A score, &gt;0 if the state benefits player 1, &lt;0 if it benefits
        /// player 2, and 0 if neither player has an advantage.
        /// </returns>
        int Evaluate();
    }
}
