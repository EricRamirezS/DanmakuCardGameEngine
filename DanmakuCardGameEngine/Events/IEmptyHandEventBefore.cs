using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="EmptyHandEvent"/> *before* its main action.
    /// Implementers can influence whether the empty hand event executes or is stopped.
    /// </summary>
    public interface IEmptyHandEventBefore {
        /// <summary>
        /// Handler method for the <see cref="EmptyHandEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="EmptyHandEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main empty hand event action.</param>
        void OnEmptyHandBefore(EmptyHandEventArgs args, out bool bubbleEvent);
    }
}