using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when an item is discarded from play or hand.
    /// Triggers item-based graveyard effects or penalties.
    /// </summary>
    public class ItemDiscardedEvent : BubblingEvent<ItemDiscardedEventArgs> { }
}