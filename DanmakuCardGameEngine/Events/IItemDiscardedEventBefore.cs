using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="ItemDiscardedEvent"/> *before* its main action.
    /// Implementers can influence whether the item discard executes or is stopped.
    /// </summary>
    public interface IItemDiscardedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="ItemDiscardedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="ItemDiscardedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main item discard action.</param>
        void OnItemDiscardedBefore(ItemDiscardedEventArgs args, out bool bubbleEvent);
    }
}