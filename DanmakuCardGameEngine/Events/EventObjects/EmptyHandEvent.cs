using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a player ends their turn with an empty hand.
    /// Can be used for effects that reward or penalize this condition.
    /// </summary>
    public class EmptyHandEvent : BubblingEvent<EmptyHandEventArgs> { }
}