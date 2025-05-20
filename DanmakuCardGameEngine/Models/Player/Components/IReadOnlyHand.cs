using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player.Components {
    public interface IReadOnlyHand {
        int Count { get; }
        int MaxHandSize { get; }
        int CardCount();
        int CardCount<T>() where T : IHandCard;
    }
}