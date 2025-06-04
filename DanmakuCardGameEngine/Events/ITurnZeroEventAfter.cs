using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="TurnZeroEvent"/> *after* its main action.
    /// Implementers react to Turn Zero once it has occurred.
    /// </summary>
    public interface ITurnZeroEventAfter {
        /// <summary>
        /// Handler method for the <see cref="TurnZeroEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="TurnZeroEventArgs"/> for the event.</param>
        void OnTurnZeroAfter(TurnZeroEventArgs args);
    }
}