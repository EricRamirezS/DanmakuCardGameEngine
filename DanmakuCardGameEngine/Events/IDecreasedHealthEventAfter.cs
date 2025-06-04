using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Defines an interface for subscribers who want to handle the <see cref="DecreasedHealthEvent"/> *after* its main action.
    /// Implementers react to the health decrease once it has occurred.
    /// </summary>
    public interface IDecreasedHealthEventAfter {
        /// <summary>
        /// Handler method for the <see cref="DecreasedHealthEvent"/> in its *After* phase.
        /// </summary>
        /// <param name="args">The <see cref="DecreasedHealthEventArgs"/> for the event.</param>
        void OnDecreasedHealthAfter(DecreasedHealthEventArgs args);
    }
}