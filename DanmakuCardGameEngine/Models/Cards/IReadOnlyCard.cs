using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    public interface IReadOnlyCard {
        ICardType CardType { get; }
    }
}