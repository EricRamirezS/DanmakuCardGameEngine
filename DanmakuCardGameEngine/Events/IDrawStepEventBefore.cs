using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DrawStepEvent"/> *before* its main action.
    /// Implementers can influence whether the draw step executes or is stopped.
    /// </summary>
    public interface IDrawStepEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DrawStepEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DrawStepEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main draw step action.</param>
        void OnDrawStepBefore(DrawStepEventArgs args, out bool bubbleEvent);
    }
}