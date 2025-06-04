using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="NewIncidentEvent"/> *after* its main action.
    /// Implementers react to the new incident revelation once it has occurred.
    /// </summary>
    public interface INewIncidentEventAfter {
        /// <summary>
        /// Handler method for the <see cref="NewIncidentEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="NewIncidentEventArgs"/> for the event.</param>
        void OnNewIncidentAfter(NewIncidentEventArgs args);
    }
}