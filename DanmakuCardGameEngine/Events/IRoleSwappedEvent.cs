using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IRoleSwappedEventBefore"/> and <see cref="IRoleSwappedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="RoleSwappedEvent"/>.
    /// </summary>
    public interface IRoleSwappedEvent : IRoleSwappedEventBefore, IRoleSwappedEventAfter { }
}