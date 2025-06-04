using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a player's role is revealed.
    /// Enables role-specific triggers and reactions.
    /// </summary>
    public class RoleRevealedEvent : BubblingEvent<RoleRevealedEventArgs> { }
}