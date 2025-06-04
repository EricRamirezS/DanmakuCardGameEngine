using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="StartOfTurnEvent"/> *after* its main action.
    /// Implementers react to the <see cref="StartOfTurnEvent"/> once it has occurred.
    /// </summary>
    public interface IStartOfTurnEventAfter {
        /// <summary>
        /// Handler method for the <see cref="StartOfTurnEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="StartOfTurnEventArgs"/> for the event.</param>
        void OnStartOfTurnAfter(StartOfTurnEventArgs args);
    }
}