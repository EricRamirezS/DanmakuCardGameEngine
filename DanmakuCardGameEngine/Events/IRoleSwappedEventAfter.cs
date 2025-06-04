using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="RoleSwappedEvent"/> *after* its main action.
    /// Implementers react to the role swap once it has occurred.
    /// </summary>
    public interface IRoleSwappedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="RoleSwappedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="RoleSwappedEventArgs"/> for the event.</param>
        void OnRoleSwappedAfter(RoleSwappedEventArgs args);
    }
}