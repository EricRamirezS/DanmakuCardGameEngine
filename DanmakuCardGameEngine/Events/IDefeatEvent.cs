using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IDefeatEventBefore"/> and <see cref="IDefeatEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DefeatEvent"/>.
    /// </summary>
    public interface IDefeatEvent : IDefeatEventBefore, IDefeatEventAfter { }
}