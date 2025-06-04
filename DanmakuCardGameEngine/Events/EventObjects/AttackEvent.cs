using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when an attack is initiated.
    /// Can be used to modify, prevent, or respond to attacks.
    /// </summary>
    public class AttackEvent : BubblingEvent<AttackEventArgs> { }
}