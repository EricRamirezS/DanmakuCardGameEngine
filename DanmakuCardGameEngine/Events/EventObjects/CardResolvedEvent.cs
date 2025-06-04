using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised after a card’s effect has fully resolved.
    /// Enables responses to resolved card effects.
    /// </summary>
    public class CardResolvedEvent : BubblingEvent<CardResolvedEventArgs> { }
}