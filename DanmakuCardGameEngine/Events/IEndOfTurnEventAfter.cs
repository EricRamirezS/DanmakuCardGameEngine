using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="EndOfTurnEvent"/> *after* its main action.
    /// Implementers react to the end of turn once it has occurred.
    /// </summary>
    public interface IEndOfTurnEventAfter {
        /// <summary>
        /// Handler method for the <see cref="EndOfTurnEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="EndOfTurnEventArgs"/> for the event.</param>
        void OnEndOfTurnAfter(EndOfTurnEventArgs args);
    }
}