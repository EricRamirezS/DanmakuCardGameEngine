using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="HandSwappedEvent"/> *before* its main action.
    /// Implementers can influence whether the hand swap executes or is stopped.
    /// </summary>
    public interface IHandSwappedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="HandSwappedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="HandSwappedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main hand swap action.</param>
        void OnHandSwappedBefore(HandSwappedEventArgs args, out bool bubbleEvent);
    }
}