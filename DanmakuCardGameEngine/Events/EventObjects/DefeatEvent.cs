using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a player is defeated.
    /// Enables reactions before and after defeat resolution.
    /// </summary>
    public class DefeatEvent : BubblingEvent<DefeatEventArgs> { }
}