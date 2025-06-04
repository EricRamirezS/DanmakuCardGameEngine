using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when an action is cancelled.
    /// Allows game components to react to or prevent the cancellation.
    /// </summary>
    public class CancelEvent : BubblingEvent<CancelEventArgs> { }
}