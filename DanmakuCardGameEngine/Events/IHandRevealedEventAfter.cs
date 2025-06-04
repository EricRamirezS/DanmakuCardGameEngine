using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="HandRevealedEvent"/> *after* its main action.
    /// Implementers react to the hand revelation once it has occurred.
    /// </summary>
    public interface IHandRevealedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="HandRevealedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="HandRevealedEventArgs"/> for the event.</param>
        void OnHandRevealedAfter(HandRevealedEventArgs args);
    }
}