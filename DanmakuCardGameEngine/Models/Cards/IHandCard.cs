using DanmakuCardGameEngine.Enums;

namespace DanmakuCardGameEngine.Models.Cards {
    public interface IHandCard : ICard {
        int PointValue { get; }
        CardMode CardMode { get; }

        bool CanBePlayed();
        bool CanPlayMainMode();
        bool CanPlayAltMode();
    }
}