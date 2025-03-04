using System.Collections;
using DanmakuCardGameEngine.Exceptions;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public class DecksManager : ReadOnlyDeckManager, IDecksManager {
        public Deck<TCard> GetDeck<TCard>() where TCard : ICard {
            if (!Decks.ContainsKey(typeof(TCard))) throw new DeckNotFoundException();

            IList deck = Decks[typeof(TCard)];
            return (Deck<TCard>)deck;
        }

        public TDeck GetDeck<TDeck, TCard>() where TDeck : IDeck<TCard> where TCard : ICard {
            if (!Decks.ContainsKey(typeof(TCard))) throw new DeckNotFoundException();

            IList deck = Decks[typeof(TCard)];
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

        public void RegisterDeck<TCard>(Deck<TCard> deck) where TCard : ICard {
            if (Decks.ContainsKey(typeof(TCard))) {
                throw new DuplicatedDeckTypeException(typeof(TCard));
            }

            Decks.Add(typeof(TCard), deck);
        }

        public void AddToDeck<TCard>(Deck<TCard> deck) where TCard : ICard {
            Deck<TCard> originalDeck = GetDeck<TCard>();
            originalDeck.AddRange(deck);
        }

        public void ShuffleAllDecks() {
            foreach (IList decksValue in Decks.Values) {
                ((IShuffleable) decksValue).Shuffle();
            }
        }
    }
}