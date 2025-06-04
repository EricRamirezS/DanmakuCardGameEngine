using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="GameStateEvent"/> *before* its main action.
    /// Implementers can influence whether the game state change executes or is stopped.
    /// </summary>
    public interface IGameStateEventBefore {
        /// <summary>
        /// Handler method for the <see cref="GameStateEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="GameStateEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main game state change action.</param>
        void OnGameStateBefore(GameStateEventArgs args, out bool bubbleEvent);
    }
}