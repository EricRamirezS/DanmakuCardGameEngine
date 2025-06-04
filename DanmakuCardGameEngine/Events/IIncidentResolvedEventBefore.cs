using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="IncidentResolvedEvent"/> *before* its main action.
    /// Implementers can influence whether the incident resolution executes or is stopped.
    /// </summary>
    public interface IIncidentResolvedEventBefore {
        /// <summary>
        /// Handler method for the <see cref="IncidentResolvedEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="IncidentResolvedEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main incident resolution action.</param>
        void OnIncidentResolvedBefore(IncidentResolvedEventArgs args, out bool bubbleEvent);
    }
}