using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when two players exchange their hands.
    /// Allows interception or modification of swaps.
    /// </summary>
    public class HandSwappedEvent : BubblingEvent<HandSwappedEventArgs> { }
}