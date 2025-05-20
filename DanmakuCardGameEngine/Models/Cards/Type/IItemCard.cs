using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Models.Cards.Type {
    public interface IItemCard {
        string Name { get; }
        IModifiers Modifiers { get; }
    }
}