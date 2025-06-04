using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DefeatEvent"/> *before* its main action.
    /// Implementers can influence whether the defeat executes or is stopped.
    /// </summary>
    public interface IDefeatEventBefore {
        /// <summary>
        /// Handler method for the <see cref="DefeatEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="DefeatEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main defeat action.</param>
        void OnDefeatBefore(DefeatEventArgs args, out bool bubbleEvent);
    }
}