using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="GameStateEvent"/> *after* its main action.
    /// Implementers react to the game state change once it has occurred.
    /// </summary>
    public interface IGameStateEventAfter {
        /// <summary>
        /// Handler method for the <see cref="GameStateEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="GameStateEventArgs"/> for the event.</param>
        void OnGameStateAfter(GameStateEventArgs args);
    }
}