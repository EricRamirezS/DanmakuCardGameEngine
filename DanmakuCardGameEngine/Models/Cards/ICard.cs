using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Type;

namespace DanmakuCardGameEngine.Models.Cards {
    public interface ICard : IReadOnlyCard {
        int Id { get; }
        string Name { get; }
        ISeason Season { get; }
        IExpansion Expansion { get; }
    }
}