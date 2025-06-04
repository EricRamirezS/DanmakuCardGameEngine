using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="TurnSkippedEvent"/> *after* its main action.
    /// Implementers react to the turn skip once it has occurred.
    /// </summary>
    public interface ITurnSkippedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="TurnSkippedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="TurnSkippedEventArgs"/> for the event.</param>
        void OnTurnSkippedAfter(TurnSkippedEventArgs args);
    }
}