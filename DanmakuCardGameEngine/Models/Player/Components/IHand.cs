using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player.Components {
    public interface IHand : IReadOnlyHand { }

    public interface IReadOnlyHand {
        int CardCount();
        int CardCount<T>() where T : IHandCard;
    }
}