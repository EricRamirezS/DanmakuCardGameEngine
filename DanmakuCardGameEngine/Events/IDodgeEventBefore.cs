using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DodgeEvent"/> *before* its main action.
    /// Implementers can influence whether the dodge executes or is stopped.
    /// </summary>
    public interface IDodgeEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DodgeEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DodgeEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main dodge action.</param>
        void OnDodgeBefore(DodgeEventArgs args, out bool bubbleEvent);
    }
}