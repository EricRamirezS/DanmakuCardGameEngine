using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IEndOfTurnEventBefore"/> and <see cref="IEndOfTurnEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="EndOfTurnEvent"/>.
    /// </summary>
    public interface IEndOfTurnEvent : IEndOfTurnEventBefore, IEndOfTurnEventAfter { }
}