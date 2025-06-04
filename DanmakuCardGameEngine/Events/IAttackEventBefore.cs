using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="AttackEvent"/> *before* its main action.
    /// Implementers can influence whether the attack executes or is stopped.
    /// </summary>
    public interface IAttackEventBefore {
        /// <summary>
        /// Handler method for the <see cref="AttackEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="AttackEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main attack action.</param>
        void OnAttackBefore(AttackEventArgs args, out bool bubbleEvent);
    }
}