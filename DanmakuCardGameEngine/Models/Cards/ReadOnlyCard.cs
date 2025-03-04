using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Models.Cards {
    public class ReadOnlyCard : IReadOnlyCard {
        public ReadOnlyCard(ICardType cardType) {
            CardType = cardType;
        }

        public ICardType CardType { get; }
        public virtual IModifiers Modifiers => Commons.Modifiers.Empty;
    }
}