using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="SpellCardCancelledEvent"/> *after* its main action.
    /// Implementers react to the spell card cancellation once it has occurred.
    /// </summary>
    public interface ISpellCardCancelledEventAfter {
        /// <summary>
        /// Handler method for the <see cref="SpellCardCancelledEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="SpellCardCancelledEventArgs"/> for the event.</param>
        void OnSpellCardCancelledAfter(SpellCardCancelledEventArgs args);
    }
}