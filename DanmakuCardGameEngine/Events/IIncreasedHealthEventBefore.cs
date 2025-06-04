using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="IncreasedHealthEvent"/> *before* its main action.
    /// Implementers can influence whether the health increase executes or is stopped.
    /// </summary>
    public interface IIncreasedHealthEventBefore {
        /// <summary>
        /// Handler method for the <see cref="IncreasedHealthEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="IncreasedHealthEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main health increase action.</param>
        void OnIncreasedHealthBefore(IncreasedHealthEventArgs args, out bool bubbleEvent);
    }
}