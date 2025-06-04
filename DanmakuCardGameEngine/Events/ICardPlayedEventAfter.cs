using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardPlayedEvent"/> *after* its main action.
    /// Implementers react to the card played once it has occurred.
    /// </summary>
    public interface ICardPlayedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="CardPlayedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardPlayedEventArgs"/> for the event.</param>
        void OnCardPlayedAfter(CardPlayedEventArgs args);
    }
}