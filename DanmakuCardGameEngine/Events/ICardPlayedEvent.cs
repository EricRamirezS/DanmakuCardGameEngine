using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="ICardPlayedEventBefore"/> and <see cref="ICardPlayedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="CardPlayedEvent"/>.
    /// </summary>
    public interface ICardPlayedEvent : ICardPlayedEventBefore, ICardPlayedEventAfter { }
}