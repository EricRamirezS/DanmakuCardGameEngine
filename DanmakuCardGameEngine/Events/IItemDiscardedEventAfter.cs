using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="ItemDiscardedEvent"/> *after* its main action.
    /// Implementers react to the item discard once it has occurred.
    /// </summary>
    public interface IItemDiscardedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="ItemDiscardedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="ItemDiscardedEventArgs"/> for the event.</param>
        void OnItemDiscardedAfter(ItemDiscardedEventArgs args);
    }
}