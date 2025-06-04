using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="ItemPlayedEvent"/> *before* its main action.
    /// Implementers can influence whether the item played executes or is stopped.
    /// </summary>
    public interface IItemPlayedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="ItemPlayedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="ItemPlayedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main item played action.</param>
        void OnItemPlayedBefore(ItemPlayedEventArgs args, out bool bubbleEvent);
    }
}