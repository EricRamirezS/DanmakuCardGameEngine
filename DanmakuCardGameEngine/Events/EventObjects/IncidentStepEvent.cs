using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised during the incident step of a turn.
    /// Triggers or manages the global incident effects.
    /// </summary>
    public class IncidentStepEvent : BubblingEvent<IncidentStepEventArgs> { }
}