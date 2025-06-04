using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="ITurnChangeEventBefore"/> and <see cref="ITurnChangeEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="TurnChangeEvent"/>.
    /// </summary>
    public interface ITurnChangeEvent : ITurnChangeEventBefore, ITurnChangeEventAfter { }
}