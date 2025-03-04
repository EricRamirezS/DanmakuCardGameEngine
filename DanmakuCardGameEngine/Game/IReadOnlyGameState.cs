using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Game {
    public interface IReadOnlyGameState {
        IPlayer ViewingPlayer { get; }
        IReadOnlyPlayer CurrentPlayer { get; }
    }
}