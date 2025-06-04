using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="HandRevealedEvent"/> *before* its main action.
    /// Implementers can influence whether the hand revelation executes or is stopped.
    /// </summary>
    public interface IHandRevealedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="HandRevealedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="HandRevealedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main hand revelation action.</param>
        void OnHandRevealedBefore(HandRevealedEventArgs args, out bool bubbleEvent);
    }
}