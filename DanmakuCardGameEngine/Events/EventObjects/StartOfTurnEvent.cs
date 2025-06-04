using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised at the start of a player's turn.
    /// Triggers turn-start effects or initial actions.
    /// </summary>
    public class StartOfTurnEvent : BubblingEvent<StartOfTurnEventArgs> { }
}