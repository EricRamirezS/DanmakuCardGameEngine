using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player.Components {
    public class ReadOnlyHand : IReadOnlyHand {
        private readonly IHand _cards;

        public int Count => _cards.Count;
        public int MaxHandSize { get; }
        public int CardCount() => _cards.Count;
        public int CardCount<T>() where T : IHandCard => _cards.CardCount<T>();

        internal ReadOnlyHand(IHand hand) {
            _cards = hand;
            MaxHandSize = hand.MaxHandSize;
        }
    }
}