using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="AbilityActivatedEvent"/> *after* its main action.
    /// Implementers react to the ability activation once it has occurred.
    /// </summary>
    public interface IAbilityActivatedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="AbilityActivatedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="AbilityActivatedEventArgs"/> for the event.</param>
        void OnAbilityActivatedAfter(AbilityActivatedEventArgs args);
    }
}