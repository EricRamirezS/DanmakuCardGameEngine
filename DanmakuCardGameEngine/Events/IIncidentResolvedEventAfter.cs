using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="IncidentResolvedEvent"/> *after* its main action.
    /// Implementers react to the incident resolution once it has occurred.
    /// </summary>
    public interface IIncidentResolvedEventAfter {
        /// <summary>
        /// Handler method for the <see cref="IncidentResolvedEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="IncidentResolvedEventArgs"/> for the event.</param>
        void OnIncidentResolvedAfter(IncidentResolvedEventArgs args);
    }
}