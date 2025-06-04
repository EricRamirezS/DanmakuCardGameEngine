using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IHandRevealedEventBefore"/> and <see cref="IHandRevealedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="HandRevealedEvent"/>.
    /// </summary>
    public interface IHandRevealedEvent : IHandRevealedEventBefore, IHandRevealedEventAfter { }
}