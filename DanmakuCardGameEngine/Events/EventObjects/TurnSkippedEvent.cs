using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a player skips their turn.
    /// Enables penalty, catch-up, or special turn-skip behavior.
    /// </summary>
    public class TurnSkippedEvent : BubblingEvent<TurnSkippedEventArgs> { }
}