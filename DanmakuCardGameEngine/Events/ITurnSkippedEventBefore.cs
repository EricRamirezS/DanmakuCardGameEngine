using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="TurnSkippedEvent"/> *before* its main action.
    /// Implementers can influence whether the turn skip executes or is stopped.
    /// </summary>
    public interface ITurnSkippedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="TurnSkippedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="TurnSkippedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main turn skip action.</param>
        void OnTurnSkippedBefore(TurnSkippedEventArgs args, out bool bubbleEvent);
    }
}