using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a player attempts to dodge an attack.
    /// Enables dodge prevention or bonuses.
    /// </summary>
    public class DodgeEvent : BubblingEvent<DodgeEventArgs> { }
}