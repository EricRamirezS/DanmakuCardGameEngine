using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a Spell Card is activated.
    /// Enables spell reactions, counters, or bonuses.
    /// </summary>
    public class SpellCardActivatedEvent : BubblingEvent<SpellCardActivatedEventArgs> { }
}