using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="ItemPlayedEvent"/> *after* its main action.
    /// Implementers react to the item played once it has occurred.
    /// </summary>
    public interface IItemPlayedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="ItemPlayedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="ItemPlayedEventArgs"/> for the event.</param>
        void OnItemPlayedAfter(ItemPlayedEventArgs args);
    }
}