using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="EndOfTurnEvent"/> *before* its main action.
    /// Implementers can influence whether the end of turn executes or is stopped.
    /// </summary>
    public interface IEndOfTurnEventBefore {
        /// <summary>
        /// Handler method for the <see cref="EndOfTurnEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="EndOfTurnEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main end of turn action.</param>
        void OnEndOfTurnBefore(EndOfTurnEventArgs args, out bool bubbleEvent);
    }
}