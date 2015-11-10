using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSuite.Games
{
    public interface IGame<T>
    {
        bool CanPlay(IMove<T> move);
        bool Play(IMove<T> move);

        T GenerateMoves(); // TODO: this is wrong return type
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
