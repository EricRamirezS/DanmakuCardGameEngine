using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised at the discard phase of a turn.
    /// Suitable for global effects tied to discard timing.
    /// </summary>
    public class DiscardStepEvent : BubblingEvent<DiscardStepEventArgs> { }
}