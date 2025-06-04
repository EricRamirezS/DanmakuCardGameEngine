using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised during the main phase of a player's turn.
    /// Enables player actions and interactions.
    /// </summary>
    public class MainStepEvent : BubblingEvent<MainStepEventArgs> { }
}