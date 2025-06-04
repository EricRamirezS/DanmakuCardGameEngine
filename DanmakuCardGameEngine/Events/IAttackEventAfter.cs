using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="AttackEvent"/> *after* its main action.
    /// Implementers react to the attack once it has occurred.
    /// </summary>
    public interface IAttackEventAfter {
        /// <summary>
        /// Handler method for the <see cref="AttackEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="AttackEventArgs"/> for the event.</param>
        void OnAttackAfter(AttackEventArgs args);
    }
}