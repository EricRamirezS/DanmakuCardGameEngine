using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when an ability is activated.
    /// Allows event listeners to intercept or respond to the activation of abilities.
    /// </summary>
    public class AbilityActivatedEvent : BubblingEvent<AbilityActivatedEventArgs> { }
}