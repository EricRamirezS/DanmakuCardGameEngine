using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardResolvedEvent"/> *before* its main action.
    /// Implementers can influence whether the card resolution executes or is stopped.
    /// </summary>
    public interface ICardResolvedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="CardResolvedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardResolvedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main card resolution action.</param>
        void OnCardResolvedBefore(CardResolvedEventArgs args, out bool bubbleEvent);
    }
}