using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CancelEvent"/> *before* its main action.
    /// Implementers can influence whether the cancellation executes or is stopped.
    /// </summary>
    public interface ICancelEventBefore {
        /// <summary>
        /// Handler method for the <see cref="CancelEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="CancelEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main cancellation action.</param>
        void OnCancelBefore(CancelEventArgs args, out bool bubbleEvent);
    }
}