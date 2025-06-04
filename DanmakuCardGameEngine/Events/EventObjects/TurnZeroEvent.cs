using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised at the beginning of the game (Turn Zero).
    /// Used to initialize game state or apply opening effects.
    /// </summary>
    public class TurnZeroEvent : BubblingEvent<TurnZeroEventArgs> { }
}