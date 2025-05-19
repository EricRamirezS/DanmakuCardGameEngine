using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Models.Cards.Type {
    public interface IItemCard {
        IModifiers Modifiers { get; }
    }
}