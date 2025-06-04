using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised at the end of a player's turn.
    /// Triggers clean-up effects or end-of-turn conditions.
    /// </summary>
    public class EndOfTurnEvent : BubblingEvent<EndOfTurnEventArgs> { }
}