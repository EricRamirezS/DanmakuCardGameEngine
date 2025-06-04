using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when cards enter the discard pile.
    /// </summary>
    public sealed class CardsEnterDiscardPileEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the discard pile component to which the cards were added.
        /// </summary>
        public IDiscard Discard { get; }
        /// <summary>
        /// Gets a list of hand cards that were discarded.
        /// </summary>
        public IList<IHandCard> DiscardedCards { get; }
    }
}