using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="CancelEvent"/> *after* its main action.
    /// Implementers react to the cancellation once it has occurred.
    /// </summary>
    public interface ICancelEventAfter {
        /// <summary>
        /// Handler method for the <see cref="CancelEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="CancelEventArgs"/> for the event.</param>
        void OnCancelAfter(CancelEventArgs args);
    }
}