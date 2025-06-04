using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a deck is shuffled.
    /// </summary>
    public sealed class DeckShuffledEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the deck that was shuffled.
        /// </summary>
        public IDeck ShuffledDeck { get; }
    }
}