using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IDodgeEventBefore"/> and <see cref="IDodgeEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="DodgeEvent"/>.
    /// </summary>
    public interface IDodgeEvent : IDodgeEventBefore, IDodgeEventAfter { }
}