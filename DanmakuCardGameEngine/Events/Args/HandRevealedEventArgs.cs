using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Player;
using DanmakuCardGameEngine.Models.Player.Components;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a player's hand is revealed.
    /// </summary>
    public sealed class HandRevealedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only hand that was revealed.
        /// </summary>
        public IReadOnlyHand Hand { get; }
        /// <summary>
        /// Gets the read-only player who revealed the hand.
        /// </summary>
        public IReadOnlyPlayer RevealingPlayer { get; }
        /// <summary>
        /// Gets or sets a list of read-only players who can view the revealed hand.
        /// </summary>
        public IList<IReadOnlyPlayer> ViewingPlayers { get; set; }
    }
}