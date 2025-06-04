using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardsEnterDiscardPileEvent"/> *before* its main action.
    /// Implementers can influence whether the card enters the discard pile or is stopped.
    /// </summary>
    public interface ICardEntersDiscardPileEventBefore {
        /// <summary>
        /// Handler method for the <see cref="CardsEnterDiscardPileEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardsEnterDiscardPileEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main action of the card entering the discard pile.</param>
        void OnCardEntersDiscardPileBefore(CardsEnterDiscardPileEventArgs args, out bool bubbleEvent);
    }
}