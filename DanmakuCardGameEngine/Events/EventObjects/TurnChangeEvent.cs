using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when the turn shifts from one player to another.
    /// Can be used to track active player changes or buffs/debuffs.
    /// </summary>
    public class TurnChangeEvent : BubblingEvent<TurnChangeEventArgs> { }
}