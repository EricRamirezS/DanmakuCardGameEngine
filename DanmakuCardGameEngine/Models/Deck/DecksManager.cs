using System;
using System.Collections;
using DanmakuCardGameEngine.Exceptions;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Manages a collection of various decks within the game, providing functionalities
    /// to retrieve, register, and manipulate decks. It extends <see cref="ReadOnlyDeckManager"/>
    /// and implements <see cref="IDecksManager"/> to offer both read-only and mutable operations.
    /// </summary>
    public class DecksManager : ReadOnlyDeckManager, IDecksManager {
        /// <inheritdoc />
        /// <exception cref="DeckNotFoundException">Thrown when no deck of the specified card type is found.</exception>
        public IDeck<TCard> GetDeck<TCard>() where TCard : ICard {
            if (!Decks.ContainsKey(typeof(TCard))) throw new DeckNotFoundException();

            IList deck = Decks[typeof(TCard)];
            return (IDeck<TCard>)deck;
        }

        /// <summary>
        /// Retrieves a non-generic deck based on a sample card's type.
        /// This method traverses the inheritance hierarchy of the sample card's type
        /// to find a matching registered deck.
        /// </summary>
        /// <param name="sampleCard">A sample card whose type is used to find the corresponding deck.</param>
        /// <returns>The found deck as an <see cref="IDeck"/>.</returns>
        /// <exception cref="DeckNotFoundException">Thrown if no deck is found for the sample card's type or its base types/interfaces.</exception>
        public IDeck GetDeck<TCard>(TCard sampleCard) where TCard : ICard {
            Type cardType = sampleCard.GetType();
            while (cardType != null && cardType != typeof(ICard)) {
                foreach (Type iface in cardType.GetInterfaces()) {
                    if (typeof(ICard).IsAssignableFrom(iface) && Decks.TryGetValue(iface, out IList deck)) {
                        return (IDeck)deck;
                    }
                }
                cardType = cardType.BaseType;
            }
            throw new DeckNotFoundException();
        }

        /// <inheritdoc />
        /// <exception cref="DeckNotFoundException">Thrown when no deck of the specified deck type is found.</exception>
        public TDeck GetDeck<TDeck, TCard>() where TDeck : IDeck<TCard> where TCard : ICard {
            Type deckType = typeof(TDeck);
            if (!Decks.TryGetValue(deckType, out IList deck)) throw new DeckNotFoundException();

            return (TDeck)deck;
        }

        /// <inheritdoc />
        public bool GetDeck<TDeck, TCard>(out TDeck deck) where TDeck : IDeck<TCard> where TCard : ICard {
            try {
                deck = GetDeck<TDeck, TCard>();
                return true;
            }
            catch {
                deck = default;
                return false;
            }
        }

        /// <inheritdoc />
        /// <exception cref="DuplicatedDeckTypeException">Thrown when a deck of the specified card type has already been registered.</exception>
        public void RegisterDeck<TCard>(IDeck<TCard> deck) where TCard : ICard {
            if (Decks.ContainsKey(typeof(TCard))) {
                throw new DuplicatedDeckTypeException(typeof(TCard));
            }

            Decks.Add(typeof(TCard), deck);
        }

        /// <inheritdoc />
        public void AddToDeck<TCard>(IDeck<TCard> deck) where TCard : ICard {
            IDeck<TCard> originalDeck = GetDeck<TCard>();
            originalDeck.AddRange(deck);
        }

        /// <summary>
        /// Shuffles all registered decks that implement <see cref="IShuffleable"/>.
        /// </summary>
        public void ShuffleAllDecks() {
            foreach (IList decksValue in Decks.Values) {
                // Cast to IShuffleable and shuffle if the deck supports it.
                if (decksValue is IShuffleable shuffleableDeck) {
                    shuffleableDeck.Shuffle();
                }
            }
        }
    }
}