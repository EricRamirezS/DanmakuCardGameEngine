using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Models.Cards {
    public interface IReadOnlyCard {
        ICardType CardType { get; }
        IModifiers Modifiers { get; }
    }
}