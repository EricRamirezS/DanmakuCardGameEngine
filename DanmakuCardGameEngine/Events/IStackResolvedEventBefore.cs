using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="StackResolvedEvent"/> *before* its main action.
    /// Implementers can influence whether the stack resolution executes or is stopped.
    /// </summary>
    public interface IStackResolvedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="StackResolvedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="StackResolvedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main stack resolution action.</param>
        void OnStackResolvedBefore(StackResolvedEventArgs args, out bool bubbleEvent);
    }
}