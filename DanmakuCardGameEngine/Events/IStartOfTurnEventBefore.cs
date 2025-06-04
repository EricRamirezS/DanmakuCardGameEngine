using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="StartOfTurnEvent"/> *before* its main action.
    /// Implementers can influence whether the turn start executes or is stopped.
    /// </summary>
    public interface IStartOfTurnEventBefore {
        /// <summary>
        /// Handler method for the <see cref="StartOfTurnEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="StartOfTurnEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main turn start action.</param>
        void OnStartOfTurnBefore(StartOfTurnEventArgs args, out bool bubbleEvent);
    }
}