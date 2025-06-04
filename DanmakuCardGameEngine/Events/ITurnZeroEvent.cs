using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="ITurnZeroEventBefore"/> and <see cref="ITurnZeroEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="TurnZeroEvent"/>.
    /// </summary>
    public interface ITurnZeroEvent : ITurnZeroEventBefore, ITurnZeroEventAfter { }
}