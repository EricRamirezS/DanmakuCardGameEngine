using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a new incident is revealed.
    /// Useful for modifying or reacting to the revealed card.
    /// </summary>
    public class NewIncidentEvent : BubblingEvent<NewIncidentEventArgs> { }
}