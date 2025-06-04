using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IItemDiscardedEventBefore"/> and <see cref="IItemDiscardedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="ItemDiscardedEvent"/>.
    /// </summary>
    public interface IItemDiscardedEvent : IItemDiscardedEventBefore, IItemDiscardedEventAfter { }
}