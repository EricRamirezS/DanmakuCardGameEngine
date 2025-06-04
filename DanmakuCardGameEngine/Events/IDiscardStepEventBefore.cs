using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DiscardStepEvent"/> *before* its main action.
    /// Implementers can influence whether the discard step executes or is stopped.
    /// </summary>
    public interface IDiscardStepEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DiscardStepEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DiscardStepEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main discard step action.</param>
        void OnDiscardStepBefore(DiscardStepEventArgs args, out bool bubbleEvent);
    }
}