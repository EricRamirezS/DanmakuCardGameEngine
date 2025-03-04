using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public class ReadOnlyDeck<TCard> : IReadOnlyDeck<TCard> where TCard : ICard {
        public ReadOnlyDeck(int count) {
            Count = count;
        }

        public int Count { get; }
    }
}