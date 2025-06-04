using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DecreasedHealthEvent"/> *before* its main action.
    /// Implementers can influence whether the health decrease executes or is stopped.
    /// </summary>
    public interface IDecreasedHealthEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DecreasedHealthEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DecreasedHealthEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main health decrease action.</param>
        void OnDecreasedHealthBefore(DecreasedHealthEventArgs args, out bool bubbleEvent);
    }
}