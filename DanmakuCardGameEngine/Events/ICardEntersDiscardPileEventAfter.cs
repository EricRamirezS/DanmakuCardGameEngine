using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardsEnterDiscardPileEvent"/> *after* its main action.
    /// Implementers react to the card entering the discard pile once it has occurred.
    /// </summary>
    public interface ICardEntersDiscardPileEventAfter {
        /// <summary>
        /// Handler method for the <see cref="CardsEnterDiscardPileEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardsEnterDiscardPileEventArgs"/> for the event.</param>
        void OnCardEntersDiscardPileAfter(CardsEnterDiscardPileEventArgs args);
    }
}