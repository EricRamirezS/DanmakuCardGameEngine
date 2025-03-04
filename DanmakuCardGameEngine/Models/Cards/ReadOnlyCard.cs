using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    public class ReadOnlyCard : IReadOnlyCard {
        public ReadOnlyCard(ICardType cardType) {
            CardType = cardType;
        }

        public ICardType CardType { get; }
    }
}