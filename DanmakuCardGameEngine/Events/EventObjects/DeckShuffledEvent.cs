using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a player's deck is shuffled.
    /// Useful for tracking or modifying shuffle behavior.
    /// </summary>
    public class DeckShuffledEvent : BubblingEvent<DeckShuffledEventArgs> { }
}