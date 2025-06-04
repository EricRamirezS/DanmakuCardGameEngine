using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="IncidentStepEvent"/> *before* its main action.
    /// Implementers can influence whether the incident step executes or is stopped.
    /// </summary>
    public interface IIncidentStepEventBefore {
        /// <summary>
        /// Handler method for the <see cref="IncidentStepEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="IncidentStepEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main incident step action.</param>
        void OnIncidentStepBefore(IncidentStepEventArgs args, out bool bubbleEvent);
    }
}