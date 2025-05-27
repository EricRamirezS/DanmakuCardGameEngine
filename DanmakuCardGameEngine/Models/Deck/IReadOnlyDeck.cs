using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Represents a read-only view of a deck, providing access to its cards and discard pile.
    /// This generic version specifies the type of cards contained within the deck.
    /// </summary>
    /// <typeparam name="TCard">The specific type of <see cref="ICard"/> that this deck contains.</typeparam>
    public interface IReadOnlyDeck<TCard>: IReadOnlyList<IReadOnlyCard> where TCard : ICard {
        /// <summary>
        /// Gets the read-only discard pile associated with this deck.
        /// </summary>
        IDiscard<TCard> Discard { get; }
    }
    
    /// <summary>
    /// Represents a read-only view of a deck, providing access to its cards and discard pile.
    /// This non-generic version provides a general view of the deck's cards.
    /// </summary>
    public interface IReadOnlyDeck: IReadOnlyList<ICard> {
        /// <summary>
        /// Gets the read-only discard pile associated with this deck.
        /// </summary>
        IDiscard Discard { get; }
    }
}