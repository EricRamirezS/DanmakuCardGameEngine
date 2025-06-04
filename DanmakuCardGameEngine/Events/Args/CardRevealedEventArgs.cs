using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a card is revealed to players.
    /// </summary>
    public sealed class CardRevealedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only card that was revealed.
        /// </summary>
        public IReadOnlyCard RevealedCard { get; }
        /// <summary>
        /// Gets the read-only player who revealed the card.
        /// </summary>
        public IReadOnlyPlayer RevealingPlayer { get; }
        /// <summary>
        /// Gets or sets a list of read-only players who can view the revealed card.
        /// </summary>
        public IList<IReadOnlyPlayer> ViewingPlayers { get; set; }
    }
}