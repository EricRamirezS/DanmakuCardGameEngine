using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DeckShuffledEvent"/> *before* its main action.
    /// Implementers can influence whether the deck shuffles or is stopped.
    /// </summary>
    public interface IDeckShuffledEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DeckShuffledEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DeckShuffledEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main deck shuffle action.</param>
        void OnDeckShuffledBefore(DeckShuffledEventArgs args, out bool bubbleEvent);
    }
}