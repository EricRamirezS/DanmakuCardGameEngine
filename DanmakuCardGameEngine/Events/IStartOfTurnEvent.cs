using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IStartOfTurnEventBefore"/> and <see cref="IStartOfTurnEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="StartOfTurnEvent"/>.
    /// </summary>
    public interface IStartOfTurnEvent : IStartOfTurnEventBefore, IStartOfTurnEventAfter { }
}