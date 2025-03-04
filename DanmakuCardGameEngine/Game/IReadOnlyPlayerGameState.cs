using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Game {
    public interface IReadOnlyPlayerGameState : IReadOnlyGameState {
        IPlayer ViewingPlayer { get; }
    }
}