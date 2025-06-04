using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DiscardEvent"/> *after* its main action.
    /// Implementers react to the discard once it has occurred.
    /// </summary>
    public interface IDiscardEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DiscardEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DiscardEventArgs"/> for the event.</param>
        void OnDiscardAfter(DiscardEventArgs args);
    }
}