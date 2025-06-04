using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="EmptyHandEvent"/> *after* its main action.
    /// Implementers react to the empty hand event once it has occurred.
    /// </summary>
    public interface IEmptyHandEventAfter {
        /// <summary>
        /// Handler method for the <see cref="EmptyHandEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="EmptyHandEventArgs"/> for the event.</param>
        void OnEmptyHandAfter(EmptyHandEventArgs args);
    }
}