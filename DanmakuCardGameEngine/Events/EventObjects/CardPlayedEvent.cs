using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a card is played from a player's hand.
    /// Allows interception before the card is resolved.
    /// </summary>
    public class CardPlayedEvent : BubblingEvent<CardPlayedEventArgs> { }
}