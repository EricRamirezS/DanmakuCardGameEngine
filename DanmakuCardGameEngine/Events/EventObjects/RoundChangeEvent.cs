using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when the round changes (after all players have taken turns).
    /// Useful for global reset or upkeep effects.
    /// </summary>
    public class RoundChangeEvent : BubblingEvent<RoundChangeEventArgs> { }
}