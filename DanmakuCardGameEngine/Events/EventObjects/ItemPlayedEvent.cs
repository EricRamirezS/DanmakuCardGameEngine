using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when an item card is played.
    /// Allows interception or enhancements to item usage.
    /// </summary>
    public class ItemPlayedEvent : BubblingEvent<ItemPlayedEventArgs> { }
}