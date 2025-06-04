using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="FlipEvent"/> *before* its main action.
    /// Implementers can influence whether the card flip executes or is stopped.
    /// </summary>
    public interface IFlipEventBefore {
        /// <summary>
        /// Handler method for the <see cref="FlipEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="FlipEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main card flip action.</param>
        void OnFlipBefore(FlipEventArgs args, out bool bubbleEvent);
    }
}