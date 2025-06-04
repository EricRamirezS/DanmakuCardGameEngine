using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IHandSwappedEventBefore"/> and <see cref="IHandSwappedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="HandSwappedEvent"/>.
    /// </summary>
    public interface IHandSwappedEvent : IHandSwappedEventBefore, IHandSwappedEventAfter { }
}