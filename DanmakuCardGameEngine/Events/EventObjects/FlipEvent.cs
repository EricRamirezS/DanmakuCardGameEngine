using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a face-down card is flipped face-up.
    /// Useful for triggering effects on reveal.
    /// </summary>
    public class FlipEvent : BubblingEvent<FlipEventArgs> { }
}