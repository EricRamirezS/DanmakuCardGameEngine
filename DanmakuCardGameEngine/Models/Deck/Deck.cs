using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Exceptions;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Tools;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Provides a concrete implementation of a generic deck of cards.
    /// This class manages a collection of <typeparamref name="TCard"/>, allowing for
    /// drawing, shuffling, and interaction with a dedicated discard pile.
    /// </summary>
    /// <typeparam name="TCard">The type of cards in the deck, constrained to implement <see cref="ICard"/>.</typeparam>
    public class Deck<TCard> : List<TCard>, IDeck<TCard> where TCard : ICard {
        private readonly IRandomGenerator _rng;

        /// <inheritdoc />
        public IDiscard<TCard> Discard { get; } = new Discard<TCard>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Deck{TCard}"/> class with a default random generator.
        /// </summary>
        protected Deck() : this(new RandomGenerator()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Deck{TCard}"/> class with a specified random generator.
        /// This constructor is private to ensure that instances are created either with the default generator
        /// or through controlled internal mechanisms.
        /// </summary>
        /// <param name="randomGenerator">The random generator to use for shuffling.</param>
        private Deck(IRandomGenerator randomGenerator) {
            _rng = randomGenerator;
        }

        /// <summary>
        /// Allows implicit conversion from a <see cref="Deck{TCard}"/> to a <see cref="ReadOnlyDeck{TCard}"/>.
        /// </summary>
        /// <param name="m">The mutable deck to convert.</param>
        /// <returns>A new <see cref="ReadOnlyDeck{TCard}"/> instance representing the read-only view of the deck.</returns>
        public static implicit operator ReadOnlyDeck<TCard>(Deck<TCard> m) {
            return new ReadOnlyDeck<TCard>(m);
        }

        /// <inheritdoc />
        /// <remarks>
        /// This implementation uses the Fisher-Yates shuffle algorithm to randomize the order of cards in the deck.
        /// </remarks>
        public void Shuffle() {
            int n = Count;
            while (n > 1) {
                n--;
                int k = _rng.Next(n + 1); // Get a random index from 0 to n (inclusive)
                // Swap the elements
                (this[k], this[n]) = (this[n], this[k]);
            }
        }

        /// <inheritdoc />
        /// <remarks>
        /// If the deck is empty when <see cref="Draw()"/> is called, all cards from the discard pile
        /// are moved back into the deck, the discard pile is cleared, and the deck is shuffled
        /// before attempting to draw a card.
        /// Throws <see cref="NoCardsLeftException{TClass}"/> if, even after reshuffling the discard,
        /// no cards are available to draw.
        /// </remarks>
        public TCard Draw() {
            if (Count <= 0) {
                // If the deck is empty, move all cards from discard back to deck
                AddRange(Discard);
                Discard.Clear();
                Shuffle();
            }

            try {
                int lastIndex = Count - 1; // Get the index of the last card (top of the deck)
                TCard card = this[lastIndex]; // Get the card
                RemoveAt(lastIndex); // Remove it from the deck
                return card; // Return the drawn card
            }
            catch (ArgumentOutOfRangeException) {
                // This catch block handles the very rare case where, even after reshuffling,
                // the deck is still empty (e.g., if both deck and discard were initially empty).
                throw new NoCardsLeftException<TCard>(this);
            }
        }

        /// <inheritdoc />
        public IList<TCard> Draw(int numberOfCard) {
            IList<TCard> list = new List<TCard>();
            while (numberOfCard-- > 0) {
                list.Add(Draw()); // Draw cards one by one
            }
            return list;
        }

        /// <inheritdoc />
        public Task AddToDiscard(TCard card) {
            Discard.Add(card); // Add the card to the generic discard pile
            return Task.CompletedTask; // Return a completed task as this is a synchronous operation
        }

        /// <inheritdoc />
        /// <remarks>
        /// Explicit implementation for <see cref="IDeck.Draw()"/> to return <see cref="ICard"/>.
        /// </remarks>
        ICard IDeck.Draw() => Draw();

        /// <inheritdoc />
        /// <remarks>
        /// Explicit implementation for <see cref="IDeck.Draw(int)"/> to return <see cref="IList{ICard}"/>.
        /// </remarks>
        IList<ICard> IDeck.Draw(int numberOfCards) => Draw(numberOfCards).Cast<ICard>().ToList();

        /// <inheritdoc />
        /// <remarks>
        /// Explicit implementation for <see cref="IDeck.AddToDiscard(ICard)"/> to handle <see cref="ICard"/>.
        /// Requires casting the input card to <typeparamref name="TCard"/>.
        /// </remarks>
        Task IDeck.AddToDiscard(ICard card) => AddToDiscard((TCard)card);

        /// <inheritdoc />
        /// <remarks>
        /// Explicit implementation for <see cref="IDeck.GetDiscard()"/> to return <see cref="IDiscard"/>.
        /// </remarks>
        IDiscard IDeck.GetDiscard() => Discard;

        /// <inheritdoc />
        public IReadOnlyDeck<TCard> ToReadOnly() {
            return new ReadOnlyDeck<TCard>(this);
        }
    }
}