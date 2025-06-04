using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="RoleRevealedEvent"/> *before* its main action.
    /// Implementers can influence whether the role revelation executes or is stopped.
    /// </summary>
    public interface IRoleRevealedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="RoleRevealedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="RoleRevealedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main role revelation action.</param>
        void OnRoleRevealedBefore(RoleRevealedEventArgs args, out bool bubbleEvent);
    }
}