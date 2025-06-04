using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when an incident card has been resolved.
    /// Useful for progressing the game or applying global effects.
    /// </summary>
    public class IncidentResolvedEvent : BubblingEvent<IncidentResolvedEventArgs> { }
}