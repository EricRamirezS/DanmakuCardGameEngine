using System.Collections.Generic;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Game;

namespace DanmakuCardGameEngine.Models.Player {
    /// <summary>
    /// Defines an interface for a component responsible for making decisions within the game,
    /// typically involving choices from a set of options. This is designed for asynchronous decision-making,
    /// allowing for player input or AI processing.
    /// </summary>
    public interface IDecisionMaker {
        /// <summary>
        /// Asynchronously prompts for a choice from a given list of options.
        /// </summary>
        /// <typeparam name="T">The type of options to choose from.</typeparam>
        /// <param name="options">A read-only list of available options.</param>
        /// <param name="gameState">The current read-only state of the game, providing context for the decision.</param>
        /// <returns>A <see cref="Task{T}"/> representing the asynchronous operation,
        /// which will complete with the chosen option.</returns>
        Task<T> ChooseAsync<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState);
    }
}