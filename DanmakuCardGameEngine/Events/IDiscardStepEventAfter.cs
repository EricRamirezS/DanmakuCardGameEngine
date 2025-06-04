using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DiscardStepEvent"/> *after* its main action.
    /// Implementers react to the discard step once it has occurred.
    /// </summary>
    public interface IDiscardStepEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DiscardStepEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DiscardStepEventArgs"/> for the event.</param>
        void OnDiscardStepAfter(DiscardStepEventArgs args);
    }
}