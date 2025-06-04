using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a Danmaku card is played.
    /// Can be used to block or respond to bullet patterns.
    /// </summary>
    public class DanmakuPlayedEvent : BubblingEvent<DanmakuPlayedEventArgs> { }
}