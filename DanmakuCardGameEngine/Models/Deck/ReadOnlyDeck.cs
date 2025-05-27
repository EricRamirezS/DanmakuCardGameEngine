using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Provides a concrete read-only implementation of a deck, derived from a list of read-only cards.
    /// It mirrors the state of an <see cref="IDeck{TCard}"/> but prevents modifications.
    /// </summary>
    /// <typeparam name="TCard">The type of cards in the deck, constrained to implement <see cref="ICard"/>.</typeparam>
    public class ReadOnlyDeck<TCard> : List<IReadOnlyCard>, IReadOnlyDeck<TCard> where TCard : ICard {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyDeck{TCard}"/> class
        /// by copying the cards and discard pile from an existing mutable deck.
        /// </summary>
        /// <param name="deck">The mutable deck to create a read-only view from.</param>
        public ReadOnlyDeck(IDeck<TCard> deck) {
            Discard = deck.Discard;
            foreach (TCard card in deck) {
                Add(card.ToReadOnly());
            }
        }

        /// <summary>
        /// Gets the read-only discard pile associated with this deck.
        /// </summary>
        public IDiscard<TCard> Discard { get; }
    }
}