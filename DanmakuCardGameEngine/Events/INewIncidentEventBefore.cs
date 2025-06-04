using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="NewIncidentEvent"/> *before* its main action.
    /// Implementers can influence whether the new incident revelation executes or is stopped.
    /// </summary>
    public interface INewIncidentEventBefore {
        /// <summary>
        /// Handler method for the <see cref="NewIncidentEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="NewIncidentEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main new incident revelation action.</param>
        void OnNewIncidentBefore(NewIncidentEventArgs args, out bool bubbleEvent);
    }
}