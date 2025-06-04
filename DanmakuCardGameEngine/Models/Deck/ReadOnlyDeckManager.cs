using System;
using System.Collections;
using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {

    /// <inheritdoc />
    public abstract class ReadOnlyDeckManager : IReadOnlyDeckManager {
        /// <summary>
        /// A protected dictionary storing decks, where the key is the <see cref="Type"/> of the card
        /// the deck contains, and the value is an <see cref="IList"/> representing the deck.
        /// </summary>
        protected readonly Dictionary<Type, IList> Decks = new Dictionary<Type, IList>();

        /// <inheritdoc />
        public IReadOnlyDeck<TCard> GetReadOnlyDeck<TCard>() where TCard : ICard {
            if (!Decks.ContainsKey(typeof(TCard))) return null;

            IList deck = Decks[typeof(TCard)];
            return ((IDeck<TCard>)deck).ToReadOnly();
        }

        /// <inheritdoc />
        public bool ContainsDeck<TCard>() where TCard : ICard {
            return Decks.ContainsKey(typeof(TCard));
        }
    }
}