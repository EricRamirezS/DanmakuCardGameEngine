using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when the overall game state changes.
    /// Useful for syncing game state transitions or saving state.
    /// </summary>
    public class GameStateEvent : BubblingEvent<GameStateEventArgs> { }
}