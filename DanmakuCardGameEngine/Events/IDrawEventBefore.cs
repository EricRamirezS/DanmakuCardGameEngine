using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DrawEvent"/> *before* its main action.
    /// Implementers can influence whether the card draw executes or is stopped.
    /// </summary>
    public interface IDrawEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DrawEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DrawEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main card draw action.</param>
        void OnDrawBefore(DrawEventArgs args, out bool bubbleEvent);
    }
}