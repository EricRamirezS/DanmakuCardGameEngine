using System;
using System.Collections;
using DanmakuCardGameEngine.Exceptions;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public class DecksManager : ReadOnlyDeckManager, IDecksManager {
        public IDeck<TCard> GetDeck<TCard>() where TCard : ICard {
            if (!Decks.ContainsKey(typeof(TCard))) throw new DeckNotFoundException();

            IList deck = Decks[typeof(TCard)];
            return (IDeck<TCard>)deck;
        }

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

        public TDeck GetDeck<TDeck, TCard>() where TDeck : IDeck<TCard> where TCard : ICard {
            Type cardType = typeof(TDeck);
            if (!Decks.TryGetValue(cardType, out IList deck)) throw new DeckNotFoundException();

            return (TDeck)deck;
        }

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

        public void RegisterDeck<TCard>(IDeck<TCard> deck) where TCard : ICard {
            if (Decks.ContainsKey(typeof(TCard))) {
                throw new DuplicatedDeckTypeException(typeof(TCard));
            }

            Decks.Add(typeof(TCard), deck);
        }
        
        public void AddToDeck<TCard>(IDeck<TCard> deck) where TCard : ICard {
            IDeck<TCard> originalDeck = GetDeck<TCard>();
            originalDeck.AddRange(deck);
        }

        public void ShuffleAllDecks() {
            foreach (IList decksValue in Decks.Values) {
                ((IShuffleable)decksValue).Shuffle();
            }
        }
    }
}