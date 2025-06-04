using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a player discards cards.
    /// Can be used to respond to or modify discards.
    /// </summary>
    public class DiscardEvent : BubblingEvent<DiscardEventArgs> { }
}