using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when cards are drawn from a deck.
    /// Allows reactions like draw prevention or bonuses.
    /// </summary>
    public class DrawEvent : BubblingEvent<DrawEventArgs> { }
}