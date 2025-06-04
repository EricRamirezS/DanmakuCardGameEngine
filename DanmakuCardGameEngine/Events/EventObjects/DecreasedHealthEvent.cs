using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a player's health decreases.
    /// Allows for reactions such as damage mitigation or triggers.
    /// </summary>
    public class DecreasedHealthEvent : BubblingEvent<DecreasedHealthEventArgs> { }
}