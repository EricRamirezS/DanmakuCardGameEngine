using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="MainStepEvent"/> *after* its main action.
    /// Implementers react to the main step once it has occurred.
    /// </summary>
    public interface IMainStepEventAfter {
        /// <summary>
        /// Handler method for the <see cref="MainStepEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="MainStepEventArgs"/> for the event.</param>
        void OnMainStepAfter(MainStepEventArgs args);
    }
}