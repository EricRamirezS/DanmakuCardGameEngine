using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CardPlayedEvent"/> *before* its main action.
    /// Implementers can influence whether the card is played or is stopped.
    /// </summary>
    public interface ICardPlayedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="CardPlayedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="CardPlayedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main card played action.</param>
        void OnCardPlayedBefore(CardPlayedEventArgs args, out bool bubbleEvent);
    }
}