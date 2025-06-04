using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IDanmakuPlayedEventBefore"/> and <see cref="IDanmakuPlayedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DanmakuPlayedEvent"/>.
    /// </summary>
    public interface IDanmakuPlayedEvent : IDanmakuPlayedEventBefore, IDanmakuPlayedEventAfter { }
}