using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="RoleRevealedEvent"/> *after* its main action.
    /// Implementers react to the role revelation once it has occurred.
    /// </summary>
    public interface IRoleRevealedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="RoleRevealedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="RoleRevealedEventArgs"/> for the event.</param>
        void OnRoleRevealedAfter(RoleRevealedEventArgs args);
    }
}