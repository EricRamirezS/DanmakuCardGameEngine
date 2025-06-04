using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="SpellCardCancelledEvent"/> *before* its main action.
    /// Implementers can influence whether the spell card cancellation executes or is stopped.
    /// </summary>
    public interface ISpellCardCancelledEventBefore {
        /// <summary>
        /// Handler method for the <see cref="SpellCardCancelledEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="SpellCardCancelledEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main spell card cancellation action.</param>
        void OnSpellCardCancelledBefore(SpellCardCancelledEventArgs args, out bool bubbleEvent);
    }
}