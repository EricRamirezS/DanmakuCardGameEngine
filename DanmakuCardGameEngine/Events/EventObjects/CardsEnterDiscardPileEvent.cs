using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Raised when a card is placed into a discard pile.
    /// Useful for effects triggered by discards.
    /// </summary>
    public class CardsEnterDiscardPileEvent : BubblingEvent<CardsEnterDiscardPileEventArgs> { }
}