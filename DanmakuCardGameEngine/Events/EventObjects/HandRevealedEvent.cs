using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a player’s hand is revealed to others.
    /// Useful for triggering inspection-based abilities.
    /// </summary>
    public class HandRevealedEvent : BubblingEvent<HandRevealedEventArgs> { }
}