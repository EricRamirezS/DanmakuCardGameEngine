using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="TurnZeroEvent"/> *before* its main action.
    /// Implementers can influence whether Turn Zero executes or is stopped.
    /// </summary>
    public interface ITurnZeroEventBefore {
        /// <summary>
        /// Handler method for the <see cref="TurnZeroEvent"/> in its *Before* phase.
        /// </summary>
        /// <param name="args">The <see cref="TurnZeroEventArgs"/> for the event.</param>
        /// <param name="bubbleEvent">An output value that, if set to <c>false</c>, will stop the execution
        /// of remaining <c>Before</c> handlers and the main Turn Zero action.</param>
        void OnTurnZeroBefore(TurnZeroEventArgs args, out bool bubbleEvent);
    }
}