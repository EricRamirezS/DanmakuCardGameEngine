using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DeckShuffledEvent"/> *after* its main action.
    /// Implementers react to the deck shuffle once it has occurred.
    /// </summary>
    public interface IDeckShuffledEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DeckShuffledEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DeckShuffledEventArgs"/> for the event.</param>
        void OnDeckShuffledAfter(DeckShuffledEventArgs args);
    }
}