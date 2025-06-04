using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IDiscardEventBefore"/> and <see cref="IDiscardEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DiscardEvent"/>.
    /// </summary>
    public interface IDiscardEvent : IDiscardEventBefore, IDiscardEventAfter { }
}