using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a player's health increases.
    /// Can trigger healing bonuses or conditions.
    /// </summary>
    public class IncreasedHealthEvent : BubblingEvent<IncreasedHealthEventArgs> { }
}