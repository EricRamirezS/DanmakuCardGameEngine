using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="RoleSwappedEvent"/> *before* its main action.
    /// Implementers can influence whether the role swap executes or is stopped.
    /// </summary>
    public interface IRoleSwappedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="RoleSwappedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="RoleSwappedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main role swap action.</param>
        void OnRoleSwappedBefore(RoleSwappedEventArgs args, out bool bubbleEvent);
    }
}