using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="ITurnSkippedEventBefore"/> and <see cref="ITurnSkippedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="TurnSkippedEvent"/>.
    /// </summary>
    public interface ITurnSkippedEvent : ITurnSkippedEventBefore, ITurnSkippedEventAfter { }
}