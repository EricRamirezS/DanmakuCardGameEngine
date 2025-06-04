using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IItemPlayedEventBefore"/> and <see cref="IItemPlayedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="ItemPlayedEvent"/>.
    /// </summary>
    public interface IItemPlayedEvent : IItemPlayedEventBefore, IItemPlayedEventAfter { }
}