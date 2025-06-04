using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when cards are drawn.
    /// </summary>
    public sealed class DrawEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the number of cards that were attempted to be drawn.
        /// </summary>
        public int cardsToDraw { get; }
        /// <summary>
        /// Gets a list of read-only cards that were drawn.
        /// </summary>
        public List<IReadOnlyCard> DrawnCards { get; }
        /// <summary>
        /// Gets the read-only player who drew the cards.
        /// </summary>
        public IReadOnlyPlayer DrawingPlayer { get; }
    }
}