using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IDeckShuffledEventBefore"/> and <see cref="IDeckShuffledEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DeckShuffledEvent"/>.
    /// </summary>
    public interface IDeckShuffledEvent : IDeckShuffledEventBefore, IDeckShuffledEventAfter { }
}