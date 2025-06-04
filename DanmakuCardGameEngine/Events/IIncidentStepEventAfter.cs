using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="IncidentStepEvent"/> *after* its main action.
    /// Implementers react to the incident step once it has occurred.
    /// </summary>
    public interface IIncidentStepEventAfter {
        /// <summary>
        /// Handler method for the <see cref="IncidentStepEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="IncidentStepEventArgs"/> for the event.</param>
        void OnIncidentStepAfter(IncidentStepEventArgs args);
    }
}