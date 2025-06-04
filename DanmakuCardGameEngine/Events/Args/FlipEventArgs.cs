using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a card is flipped from a deck.
    /// </summary>
    public sealed class FlipEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only deck from which the card was flipped.
        /// </summary>
        public IReadOnlyDeck Deck { get; }
        /// <summary>
        /// Gets the card that was flipped.
        /// </summary>
        public ICard flippedCard { get; }
    }
}