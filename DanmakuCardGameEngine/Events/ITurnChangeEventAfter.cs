using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="TurnChangeEvent"/> *after* its main action.
    /// Implementers react to the turn change once it has occurred.
    /// </summary>
    public interface ITurnChangeEventAfter {
        /// <summary>
        /// Handler method for the <see cref="TurnChangeEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="TurnChangeEventArgs"/> for the event.</param>
        void OnTurnChangeAfter(TurnChangeEventArgs args);
    }
}