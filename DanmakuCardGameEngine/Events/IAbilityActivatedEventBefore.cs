using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="AbilityActivatedEvent"/> *before* its main action.
    /// Implementers can influence whether the ability action executes or is stopped.
    /// </summary>
    public interface IAbilityActivatedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="AbilityActivatedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="AbilityActivatedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main ability action.</param>
        void OnAbilityActivatedBefore(AbilityActivatedEventArgs args, out bool bubbleEvent);
    }
}