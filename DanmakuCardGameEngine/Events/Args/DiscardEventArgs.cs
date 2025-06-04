using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when cards are discarded from a player's hand.
    /// </summary>
    public sealed class DiscardEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the player's discard component.
        /// </summary>
        public IDiscard Discard { get; }
        /// <summary>
        /// Gets the read-only player who is discarding cards.
        /// </summary>
        public IReadOnlyPlayer DiscardingPlayer { get; }
        /// <summary>
        /// Gets a list of hand cards that were discarded in this event.
        /// </summary>
        public IList<IHandCard> DiscardedCards { get; }
    }
}