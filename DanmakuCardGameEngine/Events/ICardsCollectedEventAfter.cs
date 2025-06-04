using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardsCollectedEvent"/> *after* its main action.
    /// Implementers react to the card collection once it has occurred.
    /// </summary>
    public interface ICardsCollectedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="CardsCollectedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardsCollectedEventArgs"/> for the event.</param>
        void OnCardsCollectedAfter(CardsCollectedEventArgs args);
    }
}