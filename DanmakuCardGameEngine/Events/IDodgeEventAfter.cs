using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DodgeEvent"/> *after* its main action.
    /// Implementers react to the dodge once it has occurred.
    /// </summary>
    public interface IDodgeEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DodgeEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DodgeEventArgs"/> for the event.</param>
        void OnDodgeAfter(DodgeEventArgs args);
    }
}