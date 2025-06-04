using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a Spell Card is cancelled or interrupted.
    /// Enables follow-up reactions or penalty effects.
    /// </summary>
    public class SpellCardCancelledEvent : BubblingEvent<SpellCardCancelledEventArgs> { }
}