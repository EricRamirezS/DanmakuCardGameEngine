using System.Collections.Generic;
using System.Threading;
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
        /// <param name="options">
        /// A read-only list of available options to present to the user or calling context.
        /// The method implementation determines how these options are displayed or selected
        /// (e.g. console prompt, UI in Unity, automated selection logic, etc.).
        /// </param>
        /// <param name="gameState">
        /// The current read-only state of the game, providing contextual information
        /// that can influence how the choice is presented or processed.
        /// </param>
        /// <returns>
        /// A <see cref="Task{T}"/> representing the asynchronous operation, which will complete
        /// with the option chosen from <paramref name="options"/>.
        /// </returns>
        /// <remarks>
        /// Use this method when decisions can be made independently or in parallel, without
        /// blocking other players or game logic.  
        /// This includes “play at any time” effects or scenarios where multiple players
        /// can act simultaneously even in a turn-based game.
        /// </remarks>
        Task<T> ChooseAsync<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState, CancellationToken cancellationToken = default);
        /// <summary>
        /// Prompts for a choice from a given list of options synchronously.
        /// </summary>
        /// <typeparam name="T">The type of options to choose from.</typeparam>
        /// <param name="options">
        /// A read-only list of available options to present to the user or calling context.
        /// The method implementation determines how these options are displayed or selected
        /// (e.g. console prompt, UI in Unity, automated selection logic, etc.).
        /// </param>
        /// <param name="gameState">
        /// The current read-only state of the game, providing contextual information
        /// that can influence how the choice is presented or processed.
        /// </param>
        /// <returns>The option chosen from <paramref name="options"/>.</returns>
        /// <remarks>
        /// Use this method for blocking, turn-ordered decisions where the current player
        /// must finish choosing before other players or game logic can continue.
        /// For example, when a choice must be resolved strictly in turn order and no
        /// other actions are allowed until the choice is made.
        /// </remarks>
        T Choose<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState);
    }
}