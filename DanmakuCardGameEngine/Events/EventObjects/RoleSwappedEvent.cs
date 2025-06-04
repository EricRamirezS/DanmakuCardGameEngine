using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when roles are swapped between players.
    /// Can trigger effects based on role changes.
    /// </summary>
    public class RoleSwappedEvent : BubblingEvent<RoleSwappedEventArgs> { }
}