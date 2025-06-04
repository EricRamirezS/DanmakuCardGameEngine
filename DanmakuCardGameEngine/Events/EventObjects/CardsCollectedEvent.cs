using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a group of cards is collected (e.g., drawn or taken).
    /// Allows listeners to monitor card acquisitions.
    /// </summary>
    public class CardsCollectedEvent : BubblingEvent<CardsCollectedEventArgs> { }
}