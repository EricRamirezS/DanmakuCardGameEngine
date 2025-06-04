using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="SpellCardActivatedEvent"/> *after* its main action.
    /// Implementers react to the spell card activation once it has occurred.
    /// </summary>
    public interface ISpellCardActivatedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="SpellCardActivatedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="SpellCardActivatedEventArgs"/> for the event.</param>
        void OnSpellCardActivatedAfter(SpellCardActivatedEventArgs args);
    }
}