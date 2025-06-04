using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DiscardEvent"/> *before* its main action.
    /// Implementers can influence whether the discard executes or is stopped.
    /// </summary>
    public interface IDiscardEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DiscardEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DiscardEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main discard action.</param>
        void OnDiscardBefore(DiscardEventArgs args, out bool bubbleEvent);
    }
}