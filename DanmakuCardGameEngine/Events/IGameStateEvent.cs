using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IGameStateEventBefore"/> and <see cref="IGameStateEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="GameStateEvent"/>.
    /// </summary>
    public interface IGameStateEvent : IGameStateEventBefore, IGameStateEventAfter { }
}