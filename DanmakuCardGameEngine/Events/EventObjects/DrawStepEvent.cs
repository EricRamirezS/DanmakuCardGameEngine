using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised during the draw phase of a turn.
    /// Suitable for handling automatic or mandatory draws.
    /// </summary>
    public class DrawStepEvent : BubblingEvent<DrawStepEventArgs> { }
}