using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="MainStepEvent"/> *before* its main action.
    /// Implementers can influence whether the main step executes or is stopped.
    /// </summary>
    public interface IMainStepEventBefore {
        /// <summary>
        /// Handler method for the <see cref="MainStepEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="MainStepEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main main step action.</param>
        void OnMainStepBefore(MainStepEventArgs args, out bool bubbleEvent);
    }
}