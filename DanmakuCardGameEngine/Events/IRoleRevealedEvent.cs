using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IRoleRevealedEventBefore"/> and <see cref="IRoleRevealedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="RoleRevealedEvent"/>.
    /// </summary>
    public interface IRoleRevealedEvent : IRoleRevealedEventBefore, IRoleRevealedEventAfter { }
}