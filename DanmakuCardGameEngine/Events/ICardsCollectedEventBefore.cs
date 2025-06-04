using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardsCollectedEvent"/> *before* its main action.
    /// Implementers can influence whether the card collection executes or is stopped.
    /// </summary>
    public interface ICardsCollectedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="CardsCollectedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardsCollectedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main card collection action.</param>
        void OnCardsCollectedBefore(CardsCollectedEventArgs args, out bool bubbleEvent);
    }
}