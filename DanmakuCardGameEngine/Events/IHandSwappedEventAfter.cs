using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="HandSwappedEvent"/> *after* its main action.
    /// Implementers react to the hand swap once it has occurred.
    /// </summary>
    public interface IHandSwappedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="HandSwappedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="HandSwappedEventArgs"/> for the event.</param>
        void OnHandSwappedAfter(HandSwappedEventArgs args);
    }
}