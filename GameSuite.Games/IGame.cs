using System.Collections.Generic;

namespace GameSuite.Games
{
    public interface IGame<G, M>
        where G : IGame<G, M>
        where M : IMove<G>
    {
        bool CanPlay(M move);
        bool Play(M move);
        void Undo();

        List<M> GenerateMoves();
        G GenerateChild(M move);

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
